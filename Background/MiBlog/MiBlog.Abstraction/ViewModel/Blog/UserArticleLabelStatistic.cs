﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    /// <summary>
    /// 用户文章标签统计
    /// </summary>
    public class UserArticleLabelStatistic
    {
        /// <summary>
        /// 标签名字
        /// </summary>
        public string LabelName { get; set; }

        /// <summary>
        /// 统计总数
        /// </summary>
        public int StatisticCount { get; set; }
    }
}
