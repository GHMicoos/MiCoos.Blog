using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Category
{
    /// <summary>
    /// 请求参数：添加分类
    /// </summary>
    public class ReqAddCategory
    {
        /// <summary>
        /// 分类名字
        /// </summary>
        public string Name { get; set; }
    }
}
