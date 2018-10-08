using MiBlog.Abstraction.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

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
        /// <returns></returns>
        IList<RespQueryUserInfo> QueryUserInfo(ReqQueryUserInfo param);
    }
}
