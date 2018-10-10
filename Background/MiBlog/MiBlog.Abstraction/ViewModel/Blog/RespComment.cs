using MiBlog.Abstraction.Common.DifineEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    /// <summary>
    /// 返回结果-文章评论
    /// </summary>
    public class RespComment
    {
        /// <summary>
        /// 评论id
        /// </summary>
        public Guid CommentId { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// 文章id
        /// </summary>
        public Guid ArticleId { get; set; }

        /// <summary>
        /// 父评论id
        /// </summary>
        public Guid FatherCommentId { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public Guid Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 评论状态
        /// 枚举：0正常的，1用户删除，2违法的或不合规的，3审核中
        /// </summary>
        public CommentState State { get; set; }


    }
}
