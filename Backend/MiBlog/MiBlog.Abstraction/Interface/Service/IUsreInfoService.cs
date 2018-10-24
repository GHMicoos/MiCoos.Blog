using MiBlog.Abstraction.ViewModel;
using MiBlog.Abstraction.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiBlog.Abstraction.Interface.Service
{
    /// <summary>
    /// 逻辑层-用户信息
    /// </summary>
    public interface IUsreInfoService: IBaseService
    {
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="param"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IList<RespUserInfo> QueryUserInfo(ReqQueryUserInfo param,out int count);

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool RegistUser(ReqAddLoginInfo param);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <returns></returns>
        bool UpdateUserInfo(ReqUpdateUserInfo param);
        
    }
}
