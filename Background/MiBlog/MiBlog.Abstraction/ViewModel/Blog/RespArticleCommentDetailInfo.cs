using MiBlog.Abstraction.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    /// <summary>
    /// 返回结果-文章评论详细信息
    /// </summary>
    public class RespArticleCommentDetailInfo
    {
        /// <summary>
        /// 最新热评论
        /// </summary>
        public IList<RespComment> TopHot { get; set; }

        /// <summary>
        /// 最新评论
        /// </summary>
        public IList<RespComment> TopNew { get; set; }
    }
}
