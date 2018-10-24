using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.Common
{
    /// <summary>
    /// 静态字符串
    /// </summary>
    public class CommonConstValue
    {
        /// <summary>
        /// 请求响应基类-消息-参数错误
        /// </summary>
        public const string ResponseBase_Message_ParamError = "参数错误！";

        /// <summary>
        /// 请求响应基类-消息-操作成功
        /// </summary>
        public const string ResponseBase_Message_Success = "成功！";

        /// <summary>
        /// 请求响应基类-消息-操作失败
        /// </summary>
        public const string ResponseBase_Message_Fail = "失败！";

        /// <summary>
        /// 请求响应基类-消息-操作错误
        /// </summary>
        public const string ResponseBase_Message_Error = "错误！";

        /// <summary>
        /// 请求响应基类-返回记录总数-默认值
        /// </summary>
        public const int ResponseBase_DefaultRecordCount = 0;
    }
}
