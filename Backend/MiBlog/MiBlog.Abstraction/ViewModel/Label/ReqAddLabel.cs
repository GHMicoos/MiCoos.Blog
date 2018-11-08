using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Label
{
    /// <summary>
    /// 请求参数：新增标签
    /// </summary>
    public class ReqAddLabel
    {
        /// <summary>
        /// 标签名字
        /// </summary>
        public string Name { get; set; }
    }
}
