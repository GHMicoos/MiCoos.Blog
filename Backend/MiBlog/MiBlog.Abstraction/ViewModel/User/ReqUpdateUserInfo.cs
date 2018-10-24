using MiBlog.Abstraction.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.User
{
    /// <summary>
    /// 请求参数-修改用户资料
    /// </summary>
    public class ReqUpdateUserInfo
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string ProfilePicture { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [RegularExpression(CommonTool.MobileRegex)]
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [RegularExpression(CommonTool.EmailRegex)]
        public string Email { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        
    }
}
