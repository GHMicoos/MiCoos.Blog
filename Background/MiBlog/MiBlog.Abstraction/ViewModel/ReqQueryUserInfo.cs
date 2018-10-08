using MiBlog.Abstraction.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel
{
    /// <summary>
    /// 请求参数-查询用户信息
    /// </summary>
    public class ReqQueryUserInfo: RequestBase
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public Guid Name { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegistTime { get; set; }
    }
}
