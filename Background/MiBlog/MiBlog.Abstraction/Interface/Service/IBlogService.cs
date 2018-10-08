using MiBlog.Abstraction.ViewModel;
using MiBlog.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.Interface.Service
{
    public interface IBlogService: IBaseService
    {
        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <returns></returns>
        IList<RespQueryUserInfo> QueryUserInfo();
    }
}
