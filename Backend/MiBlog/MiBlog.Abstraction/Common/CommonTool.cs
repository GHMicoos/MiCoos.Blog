using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MiBlog.Abstraction.Common
{
    public class CommonTool
    {
        public string s = ",<.>/?;:'\"[{]}\\|=+-_)(*&^%$#@!`~*-+";

        /// <summary>
        /// 登录名 正则表达式字符串
        /// </summary>
        public const string LoginNameRegex = @"^([a-zA-Z]|[0-9]){3,20}$";
        /// <summary>
        /// 登录名 正则表达式
        /// </summary>
        /// <returns></returns>
        public static Regex GetLoginNameRegex()
            => new Regex(@"^([a-zA-Z]|[0-9]){3,20}$");

        /// <summary>
        /// 登录名 正则表达式字符串
        /// </summary>
        public const string PasswordRegex = @"^([a-zA-Z]|[0-9]){3,20}$";
        /// <summary>
        /// 登录密码 正则表达式
        /// </summary>
        /// <returns></returns>
        public static Regex GetPasswordRegex()
            => new Regex("^([a-zA-Z]|[0-9]|[,<.>/?;:'\"[{]}\\|=+-_)(*&^%$#@!`~*-+]){6,15}$");

        /// <summary>
        /// 登录名 正则表达式字符串
        /// </summary>
        public const string MobileRegex = @"^([a-zA-Z]|[0-9]){3,20}$";
        /// <summary>
        /// 手机号 正则表达式
        /// </summary>
        /// <returns></returns>
        public static Regex GetMobileRegex()
            => new Regex(@"^1[0-9]{10}$");

        /// <summary>
        /// 登录名 正则表达式字符串
        /// </summary>
        public const string EmailRegex = @"^([a-zA-Z]|[0-9]){3,20}$";
        /// <summary>
        /// 邮箱 正则表达式
        /// 只允许英文字母、数字、下划线、英文句号、以及中划线组成
        /// </summary>
        /// <returns></returns>
        public static Regex GetEmailRegex()
            => new Regex(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$");
    }
}
