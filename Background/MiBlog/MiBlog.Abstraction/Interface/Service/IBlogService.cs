using MiBlog.Abstraction.ViewModel;
using MiBlog.Abstraction.ViewModel.Blog;
using MiBlog.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MiBlog.Abstraction.AutoMapper.BlogProfile;

namespace MiBlog.Abstraction.Interface.Service
{
    public interface IBlogService: IBaseService
    {
        
        /// <summary>
        /// 查询文章详细信息
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        RespArticleDetailInfo QueryArticleDetailInfo(Guid param);

        /// <summary>
        /// 查询文章评论信息
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        RespArticleCommentDetailInfo QueryArticleCommentDetailInfo(ReqArticleCommentDetailInfo param);

        /// <summary>
        /// 查询用户的文章榜单 推荐/阅读/热评
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        UserArticleRank QueryUserArticleRank(Guid userId);

        /// <summary>
        /// 查询用户的文章统计
        /// 1.榜单
        /// 2.用户文章 分类统计
        /// 3.用户文章 标签统计
        /// 4.用户文章 时间统计
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        RespUserArticleStatistic QueryUserArticleStatistic(Guid param);
    }
}
