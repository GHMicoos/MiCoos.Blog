using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.Common.DifineEnum
{
    /// <summary>
    /// 用户(单个)文章排行类型
    /// </summary>
    public enum UserArticleRankType
    {
        /// <summary>
        /// 最新榜单
        /// </summary>
        Newest=0,

        /// <summary>
        /// 阅读榜
        /// </summary>
        MostView=1,

        /// <summary>
        /// 最多评论
        /// </summary>
        MostComment=2,
    }
}
