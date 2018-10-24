using MiBlog.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    /// <summary>
    /// 文章排行榜项
    /// </summary>
    public class ArticleRankItem
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="article"></param>
        public ArticleRankItem(TArticle article)
        {
            this.Title = article?.Title;
            this.BriefIntroduction = article?.ContentText.Substring(0, 50);
            this.ArticleId = article.ArticleId;
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } 

        /// <summary>
        /// 文章简介
        /// </summary>
        public string BriefIntroduction { get; set; }

        /// <summary>
        /// 文章Id
        /// </summary>
        public string ArticleId { get; set; }
    }
}
