using MiBlog.Abstraction.ViewModel.Label;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.Interface.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILabelService: IBaseService
    {
        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool AddLabel(ReqAddLabel param);

        /// <summary>
        /// 删除标签，如果该标签无文章关联
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool DeleteLabelIfNoArticle(ReqAddLabel param);

        /// <summary>
        /// 查询标签名称列表
        /// </summary>
        /// <returns></returns>
        List<string> QueryLabel();
    }
}
