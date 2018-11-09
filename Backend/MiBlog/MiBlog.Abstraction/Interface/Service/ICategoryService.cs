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
        /// <param name="param"></param>
        /// <returns></returns>
        bool AddCategory(ReqAddCategory param);


        /// <summary>
        /// 删除分类 当分类没有文章关联
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool DeleteCategoryIfNoArticle(ReqAddCategory param);

        /// <summary>
        /// 查询标签名称列表
        /// </summary>
        /// <returns></returns>
        List<string> QueryCategory();
    }
}
