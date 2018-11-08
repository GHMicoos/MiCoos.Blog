using MiBlog.Abstraction.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.Interface.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICategoryService: IBaseService
    {
        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        bool AddCategory(ReqAddCategory param);
    }
}
