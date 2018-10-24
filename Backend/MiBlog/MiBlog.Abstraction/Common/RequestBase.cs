using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.Common
{
    /// <summary>
    /// 请求基类
    /// </summary>
    public class RequestBase
    {
        public RequestBase() { }

        /// <summary>
        /// 是否分页
        /// </summary>
        public bool IsPage { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; }
        
    }
}
