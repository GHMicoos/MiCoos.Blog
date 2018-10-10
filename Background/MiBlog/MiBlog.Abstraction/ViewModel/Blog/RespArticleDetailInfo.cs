using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    public class RespArticleDetailInfo
    {
        /// <summary>
        /// 文章信息
        /// </summary>
        public RespArticleInfo ArticleInfo { get; set; }

        /// <summary>
        /// 作者详细信息
        /// </summary>
        public RespUserInfo AuthorInfo { get; set; }

        /// <summary>
        /// 标签信息
        /// </summary>
        public List<RespLabel> LabelList { get; set; }

        /// <summary>
        /// 文章评论总数
        /// </summary>
        public int CommentCount { get; set; }
    }
}
