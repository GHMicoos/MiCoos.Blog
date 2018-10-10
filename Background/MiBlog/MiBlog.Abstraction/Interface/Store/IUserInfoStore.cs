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

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool AddUserInfo(TUserInfo data);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool UpdateUserInfo(TUserInfo data);

        /// <summary>
        /// 添加登录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool AddLoginInfo(TLoginInfo data);

        /// <summary>
        /// 查询登录信息
        /// </summary>
        /// <returns></returns>
        IQueryable<TLoginInfo> QueryLoginInfo();
    }
}
