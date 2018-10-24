using AutoMapper;
using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Common.DifineEnum;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.Interface.Store;
using MiBlog.Abstraction.ViewModel;
using MiBlog.Abstraction.ViewModel.Blog;
using MiBlog.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MiBlog.Abstraction.AutoMapper.BlogProfile;

namespace MiBlog.Service
{
    public class BlogService : BaseService, IBlogService
    {
        private readonly IConfiguration _config;
        private readonly IBlogStore _store;
        private readonly IMapper _mapper;

        public BlogService(IConfiguration config, IMapper mapper, IBlogStore store)
        {
            _config = config;
            _mapper = mapper;
            _store = store;
        }

        /// <summary>
        /// 查询文章详细信息
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        public RespArticleDetailInfo QueryArticleDetailInfo(Guid param)
        {
            var result = default(RespArticleDetailInfo);
            var articleId = param.ToString().ToLower();
            var article = _store.QueryArticle()
                  .Include(x => x.AuthorNavigation)
                  .FirstOrDefault(x => x.ArticleId == articleId);
            if (article == null) throw new Exception($"我找到对应的文章。文章id：{param}");
            var articleInfo = _mapper.Map<TArticle, RespArticleInfo>(article);
            var authorInfo = _mapper.Map<TUserInfo, RespUserInfo>(article.AuthorNavigation);

            var labelArticleList = _store.QueryLabelArticle()
                  .Include(x => x.Label)
                  .Where(x => x.ArticleId == articleId)
                  .ToList();
            var labelList = new List<RespLabel>();
            for (int i = 0, ilen = labelArticleList?.Count ?? 0; i < ilen; i++)
                labelList.Add(_mapper.Map<TLabel, RespLabel>(labelArticleList[i].Label));

            var commentCount = _store.QueryComment().Count(x => x.ArticleId == articleId);

            result = new RespArticleDetailInfo()
            {
                ArticleInfo = articleInfo,
                AuthorInfo = authorInfo,
                LabelList = labelList,
                CommentCount = commentCount,
            };

            return result;
        }

        /// <summary>
        /// 查询文章评论信息
        /// 
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        public RespArticleCommentDetailInfo QueryArticleCommentDetailInfo(ReqArticleCommentDetailInfo param)
        {
            var result = default(RespArticleCommentDetailInfo);

            var articleId = param.ArticleId.GuidToLowerString();

            var allCommnet = _store.QueryComment()
                    .Include(x => x.Creator)
                    .Where(x => x.ArticleId == articleId)
                    .ToList();

            var userIdList = new List<TUserInfo>();

            var topHotIdList = allCommnet
                    .Where(x => x.RootCommentId != null)
                    .GroupBy(x => x.RootCommentId)
                    .Select(x => new { CommentId = x.Key, Sum = x.Count() })
                    .OrderByDescending(x => x.Sum)
                    .Take(param.TopHotCommnetCount)
                    .ToList()
                    .Select(x => x.CommentId) ?? new List<string>();

            var topHot = allCommnet
                    .Where(x => topHotIdList.Contains(x.CommentId))
                    .ToList();
            var topHotData = new List<RespComment>();
            for (int i = 0, ilen = topHot.Count; i < ilen; i++)
            {
                var add = _mapper.Map<TComment, RespComment>(topHot[i]);
                topHotData.Add(add);
                DealChildComment(add, add, allCommnet);
            }


            var topNew = allCommnet
                    .Where(x => x.RootCommentId == null)
                    .OrderByDescending(x => x.CreateTime)
                    .Skip((param.PageIndex - 1) * param.PageSize)
                    .Take(param.PageSize)
                    .ToList();
            var topNewData = new List<RespComment>();
            for (int i = 0, ilen = topNew.Count; i < ilen; i++)
            {
                var add = _mapper.Map<TComment, RespComment>(topNew[i]);
                topHotData.Add(add);
                DealChildComment(add, add, allCommnet);
            }



            result = new RespArticleCommentDetailInfo()
            {
                TopHot = topHotData,
                TopNew = topNewData,
            };

            return result;
        }

        private void DealChildComment(RespComment root, RespComment father, IList<TComment> allCommnet)
        {
            var children = allCommnet
                    .Where(x => x.FatherCommentId == father.CommentId.GuidToLowerString())
                    .ToList();

            root.ChildCommentList = root.ChildCommentList ?? new List<RespComment>();
            for (int i = 0, ilen = children.Count; i < ilen; i++)
            {
                var add = _mapper.Map<TComment, RespComment>(children[i]);
                add.FatherCommentCreator = father.CreatorNavigation;
                root.ChildCommentList.Add(add);
                DealChildComment(root, add, allCommnet);
            }
        }

        /// <summary>
        /// 查询用户的文章榜单 推荐/阅读/热评
        /// 1.推荐榜 算法
        ///   1)最新的10篇文章
        /// 2.阅读榜 算法
        ///   1)最新的10篇文章
        /// 3.热评榜 算法
        ///   1)最多评论10篇文章
        /// </summary>
        /// <param name="param">用户id</param>
        /// <returns></returns>
        public UserArticleRank QueryUserArticleRank(Guid userId)
        {
            var articleList = _store.QueryArticle()
                  .Include(x => x.TComment)
                  .Where(x => x.ArticleId == userId.GuidToLowerString() && x.State == (int)ArticleState.Publish)
                  .ToList();

            var recommendArticleListCount = 10;
            var recommendArticleListData = articleList.OrderByDescending(x => x.PublistTime).Take(recommendArticleListCount).ToList() ?? new List<TArticle>();
            var recommendArticleList = new List<ArticleRankItem>();
            for (int i = 0, ilen = recommendArticleListData.Count(); i < ilen; i++)
                recommendArticleList.Add(new ArticleRankItem(recommendArticleListData[i]));

            var mostReadArticleListCount = 10;
            //var mostReadArticleListData = articleList.OrderByDescending(x => x.PublistTime).Take(recommendArticleListCount).ToList() ?? new List<TArticle>();
            var mostReadArticleListList = recommendArticleList;

            var mostCommentArticleListCount = 10;
            var mostCommentArticleListData = articleList.OrderByDescending(x => x.TComment.Count())
                    .Take(mostCommentArticleListCount).ToList() ?? new List<TArticle>();
            var mostCommentArticleList = new List<ArticleRankItem>();
            for (int i = 0, ilen = recommendArticleListData.Count(); i < ilen; i++)
                mostCommentArticleList.Add(new ArticleRankItem(mostCommentArticleListData[i]));

            var result = new UserArticleRank()
            {
                RecommendArticleList= recommendArticleList,
                MostReadArticleList= mostReadArticleListList,
                MostCommentArticleList= mostCommentArticleList,
            };

            return result;
        }

        /// <summary>
        /// 查询用户的文章统计
        /// 1.榜单
        /// 2.用户文章 分类统计
        /// 3.用户文章 标签统计
        /// 4.用户文章 时间统计
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        public RespUserArticleStatistic QueryUserArticleStatistic(Guid param)
        {
            var userId = param.GuidToLowerString();

            var articleList = _store.QueryArticle()
                  .Include(x => x.TComment)
                  .Where(x => x.ArticleId == param.GuidToLowerString() && x.State == (int)ArticleState.Publish)
                  .ToList();

            #region 处理榜单
            
            var recommendArticleListCount = 10;
            var recommendArticleListData = articleList.OrderByDescending(x => x.PublistTime).Take(recommendArticleListCount).ToList() ?? new List<TArticle>();
            var recommendArticleList = new List<ArticleRankItem>();
            for (int i = 0, ilen = recommendArticleListData.Count(); i < ilen; i++)
                recommendArticleList.Add(new ArticleRankItem(recommendArticleListData[i]));

            var mostReadArticleListCount = 10;
            //var mostReadArticleListData = articleList.OrderByDescending(x => x.PublistTime).Take(recommendArticleListCount).ToList() ?? new List<TArticle>();
            var mostReadArticleListList = recommendArticleList;

            var mostCommentArticleListCount = 10;
            var mostCommentArticleListData = articleList.OrderByDescending(x => x.TComment.Count())
                    .Take(mostCommentArticleListCount).ToList() ?? new List<TArticle>();
            var mostCommentArticleList = new List<ArticleRankItem>();
            for (int i = 0, ilen = recommendArticleListData.Count(); i < ilen; i++)
                mostCommentArticleList.Add(new ArticleRankItem(mostCommentArticleListData[i]));

            var rank = new UserArticleRank()
            {
                RecommendArticleList = recommendArticleList,
                MostReadArticleList = mostReadArticleListList,
                MostCommentArticleList = mostCommentArticleList,
            };
            #endregion

            #region 处理分类统计

            var categoryStatisticData= _store.QueryCategoryArticle()
                  .Include(x => x.Category)
                  .Where(x => x.Category != null && x.Category.IsDelete == 0 && x.Category.Creator == userId)
                  .GroupBy(x => x.Category)
                  .Select(x => new UserArticleCategoryStatistic { CategoryName = x.Key.Name, StatisticCount = x.Count()})
                  .OrderByDescending(x=>x.StatisticCount)
                  .ToList()??new List<UserArticleCategoryStatistic>();

            #endregion

            #region 处理标签统计

            var labelStatisticData = _store.QueryLabelArticle()
                    .Include(x => x.Article)
                    .Where(x => x.Label != null && x.Label.IsDelete == 0 && x.Label.Creator == userId)
                    .GroupBy(x => x.Label)
                    .Select(x => new UserArticleLabelStatistic { LabelName = x.Key.Name, StatisticCount = x.Count() })
                    .OrderBy(x => x.StatisticCount)
                    .ToList() ?? new List<UserArticleLabelStatistic>();

            #endregion

            #region 处理时间统计

            var dateStatisticData=articleList.Where(x => x.PublistTime.ConvertToDateTime().HasValue)
                .Select(x => new { DateName = x.PublistTime.ConvertToDateTime().Value.ToString("yyyy年MM月"), ArticleId = x.ArticleId })
                .GroupBy(x => x.DateName)
                .Select(x => new UserArticleDateStatistic { DateName = x.Key, StatisticCount = x.Count() })
                .OrderByDescending(x => x.DateName)
                .ToList()??new List<UserArticleDateStatistic>();

            #endregion

            var result = new RespUserArticleStatistic()
            {
                UserArticleRank=rank,
                UserArticleCategoryStatisticList=categoryStatisticData,
                UserArticleLabelStatisticList=labelStatisticData,
                UserArticleDateStatisticList=dateStatisticData,
            };

            return null;
        }
    }
}
