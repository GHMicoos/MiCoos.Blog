using AutoMapper;
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

        public BlogService(IConfiguration config, IMapper mapper,IBlogStore store)
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
            var article=_store.QueryArticle()
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
                AuthorInfo= authorInfo,
                LabelList= labelList,
                CommentCount=commentCount,
            };

            return result;
        }
        
    }
}
