using MiBlog.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiBlog.Abstraction.Interface.Store
{
    /// <summary>
    /// 存储层-用户信息
    /// </summary>
    public interface IUserInfoStore
    {
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        IQueryable<TUserInfo> QueryUserInfo();
    }
}
