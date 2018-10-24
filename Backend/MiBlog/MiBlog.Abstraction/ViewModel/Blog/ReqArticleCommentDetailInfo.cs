using MiBlog.Abstraction.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    /// <summary>
    /// 请求参数：查询文章评论详细信息
    /// </summary>
    public class ReqArticleCommentDetailInfo: RequestBase
    {
        /// <summary>
        /// 文章id
        /// </summary>
        public Guid ArticleId { get; set; }

        /// <summary>
        /// 最热文章数
        /// </summary>
        public int TopHotCommnetCount { get; set; }
    }
}
