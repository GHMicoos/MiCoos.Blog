using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    /// <summary>
    /// 返回结果类-文章表
    /// </summary>
   public  class RespArticleInfo
    {
        /// <summary>
        /// 文章id
        /// </summary>
        public Guid ArticleId { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string ContentText { get; set; }

        /// <summary>
        /// 作者id
        /// </summary>
        public Guid Author { get; set; }

        /// <summary>
        /// 文章状态
        /// </summary>
        public long State { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublistTime { get; set; }

        

    }
}
