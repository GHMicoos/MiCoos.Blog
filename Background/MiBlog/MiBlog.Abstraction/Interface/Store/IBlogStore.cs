using MiBlog.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiBlog.Abstraction.Interface.Store
{
    public interface IBlogStore
    {
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        IQueryable<TUserInfo> QueryUserInfo();
    }
}
