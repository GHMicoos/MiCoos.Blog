using MiBlog.Abstraction.Interface.Store;
using MiBlog.EF;
using MiBlog.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiBlog.Store
{
    public class UserInfoStore : IUserInfoStore
    {
        private readonly IConfiguration _config;
        private readonly IBlogDBContext _dbContext;

        public UserInfoStore(IConfiguration config, IBlogDBContext dbContext)
        {
            _config = config;
            _dbContext = dbContext;
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<TUserInfo> QueryUserInfo()
            => _dbContext.TUserInfo.AsNoTracking();

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddUserInfo(TUserInfo data)
        {
            _dbContext.TUserInfo.Add(data);
            _dbContext.Save();
            return true;
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(TUserInfo data)
        {
            _dbContext.TUserInfo.Update(data);
            _dbContext.Save();
            return true;
        }

        /// <summary>
        /// 添加登录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddLoginInfo(TLoginInfo data)
        {
            _dbContext.TLoginInfo.Add(data);
            _dbContext.Save();
            return true;
        }

        /// <summary>
        /// 查询登录信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<TLoginInfo> QueryLoginInfo()
            => _dbContext.TLoginInfo.AsNoTracking();


    }
}
