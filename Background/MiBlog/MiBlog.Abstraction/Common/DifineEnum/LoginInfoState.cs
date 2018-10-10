using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.Common.DifineEnum
{
    /// <summary>
    /// 登录信息状态
    /// 枚举：0有效的，1禁用
    /// </summary>
    public enum LoginInfoState
    {
        /// <summary>
        /// 0有效的
        /// </summary>
        Available=0,

        /// <summary>
        /// 1禁用
        /// </summary>
        Disabled=1,
    }
}
