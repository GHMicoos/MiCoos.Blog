using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    /// <summary>
    /// 返回结果：用户文章排行榜（推荐，阅读，热评）
    /// </summary>
    public class UserArticleRank
    {
        /// <summary>
        /// 推荐 榜单
        /// </summary>
        public IList<ArticleRankItem> RecommendArticleList { get; set; }

        /// <summary>
        /// 最多阅读 榜单
        /// </summary>
        public IList<ArticleRankItem> MostReadArticleList { get; set; }

        /// <summary>
        /// 最多评论 榜单
        /// </summary>
        public IList<ArticleRankItem> MostCommentArticleList { get; set; }
    }

    
}
