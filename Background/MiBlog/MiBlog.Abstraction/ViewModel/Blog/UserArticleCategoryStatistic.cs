using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    /// <summary>
    /// 用户文章分类统计
    /// </summary>
    public class UserArticleCategoryStatistic
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 统计总数
        /// </summary>
        public int StatisticCount { get; set; }
    }
}
