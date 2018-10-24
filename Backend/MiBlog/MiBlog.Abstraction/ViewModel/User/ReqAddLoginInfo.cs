using MiBlog.Abstraction.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.User
{
    /// <summary>
    /// 请求参数-注册账号
    /// </summary>
    public class ReqAddLoginInfo
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [RegularExpression(CommonTool.LoginNameRegex)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [RegularExpression(CommonTool.PasswordRegex)]
        public string Password { get; set; }
    }
}
