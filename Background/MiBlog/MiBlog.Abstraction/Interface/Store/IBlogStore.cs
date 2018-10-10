using MiBlog.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiBlog.Abstraction.Interface.Store
{
    public interface IBlogStore
    {
        /// <summary>
        /// 查询文章
        /// </summary>
        /// <returns></returns>
        IQueryable<TArticle> QueryArticle();

        /// <summary>
        /// 查询 文章标签表
        /// </summary>
        /// <returns></returns>
        IQueryable<TLabelArticle> QueryLabelArticle();


        /// <summary>
        /// 查询 评论
        /// </summary>
        /// <returns></returns>
        IQueryable<TComment> QueryComment();
    }
}
