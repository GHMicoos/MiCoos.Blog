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
        /// <param name="param">文章id</param>
        /// <returns></returns>
        bool AddLabel(ReqAddLabel param);
    }
}
