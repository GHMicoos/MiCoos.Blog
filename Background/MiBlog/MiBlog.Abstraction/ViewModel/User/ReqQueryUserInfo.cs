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
        public string Name { get; set; }

        /// <summary>
        /// 注册时间-开始
        /// </summary>
        public DateTime? RegistTimeStart { get; set; }

        /// <summary>
        /// 注册时间-结束
        /// </summary>
        public DateTime? RegistTimeEnd { get; set; }
    }
}
