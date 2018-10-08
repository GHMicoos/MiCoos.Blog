using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.Common
{
    /// <summary>
    /// 请求响应类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseBase<T>
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public ResponseBase() { }

        /// <summary>
        /// 响应状态
        /// 枚举：0失败，1成功，2错误
        /// </summary>
        public ResponseStatus Status { get; set; }

        /// <summary>
        /// 响应消息字符串
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        public int RecordCount{get;set;}
    }
}
