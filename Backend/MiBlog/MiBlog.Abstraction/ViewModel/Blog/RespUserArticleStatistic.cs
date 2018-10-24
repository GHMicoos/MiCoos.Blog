using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    /// <summary>
    /// 用户文章统计
    /// </summary>
    public class RespUserArticleStatistic
    {
        /// <summary>
        /// 用户文章榜单
        /// </summary>
        public UserArticleRank UserArticleRank { get; set; }

        /// <summary>
        /// 用户文章 分类统计
        /// </summary>
        public IList<UserArticleCategoryStatistic> UserArticleCategoryStatisticList { get; set; }

        /// <summary>
        /// 用户文章 标签统计
        /// </summary>
        public IList<UserArticleLabelStatistic> UserArticleLabelStatisticList { get; set; }

        /// <summary>
        /// 用户文章 时间统计
        /// </summary>
        public IList<UserArticleDateStatistic> UserArticleDateStatisticList { get; set; }
    }
}
