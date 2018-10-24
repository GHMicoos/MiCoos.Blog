using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.Common
{
    /// <summary>
    /// 响应状态
    /// 枚举：0失败，1成功，2错误
    /// </summary>
    public enum ResponseStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success=0,

        /// <summary>
        /// 失败
        /// </summary>
        Fail =1,

        /// <summary>
        /// 错误
        /// </summary>
        Error =2,
    }
}
