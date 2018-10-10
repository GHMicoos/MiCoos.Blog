using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.Common.DifineEnum
{
    /// <summary>
    /// 评论状态
    /// 枚举：0正常的，1用户删除，2违法的或不合规的，3审核中
    /// </summary>
    public enum CommentState
    {
        /// <summary>
        /// 0正常的
        /// </summary>
        Normal=0,

        /// <summary>
        /// 1用户删除
        /// </summary>
        UserDelted = 1,

        /// <summary>
        /// 2违法的或不合规的
        /// </summary>
        Illegal = 2,

        /// <summary>
        /// 3审核中
        /// </summary>
        InReview = 3,
    }
}
