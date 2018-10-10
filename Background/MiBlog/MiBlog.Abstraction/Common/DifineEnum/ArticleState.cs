using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.Common.DifineEnum
{
    /// <summary>
    /// 文章状态
    /// 枚举：0草稿，1发布，2删除
    /// </summary>
    public enum ArticleState
    {
        /// <summary>
        /// 0草稿
        /// </summary>
        Draft=0,

        /// <summary>
        /// 1发布
        /// </summary>
        Publish=1,

        /// <summary>
        /// 2删除
        /// </summary>
        Delete=2,
    }
}
