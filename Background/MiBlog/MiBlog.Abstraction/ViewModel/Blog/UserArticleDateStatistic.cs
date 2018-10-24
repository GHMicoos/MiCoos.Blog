using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    /// <summary>
    /// 用户文章 时间统计
    /// </summary>
    public class UserArticleDateStatistic
    {
        /// <summary>
        /// 时间名字
        /// </summary>
        public string DateName { get; set; }

        /// <summary>
        /// 统计总数
        /// </summary>
        public int StatisticCount { get; set; }
    }
}
