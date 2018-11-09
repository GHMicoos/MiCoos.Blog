using MiBlog.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiBlog.Abstraction.Interface.Store
{
    public interface ILabelStore
    {
        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool AddLabel(TLabel data);

        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool DeleteLabel(TLabel data);

        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool UpdateLabel(TLabel data);

        /// <summary>
        /// 查询标签
        /// </summary>
        /// <returns></returns>
        IQueryable<TLabel> QueryLabel();
    }
}
