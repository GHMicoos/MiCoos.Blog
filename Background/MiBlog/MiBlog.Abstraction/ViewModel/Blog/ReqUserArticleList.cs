using MiBlog.Abstraction.Common.DifineEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    /// <summary>
    /// 请求参数：程序用户文章列表
    /// </summary>
    public class ReqUserArticleList
    {
        /// <summary>
        /// 用户文章排行类型
        /// </summary>
        public UserArticleRankType? UserArticleRankType { get; set; }

        /// <summary>
        /// 标签id
        /// </summary>
        public Guid? LabelId{get;set;}

        /// <summary>
        /// 类型id
        /// </summary>
        public Guid? CategoryId { get; set; }
    }
}
