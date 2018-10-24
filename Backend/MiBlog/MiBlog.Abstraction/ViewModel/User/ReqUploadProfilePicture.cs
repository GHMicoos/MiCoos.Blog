using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel
{
    /// <summary>
    /// 请求参数：上传用户头像
    /// </summary>
    public class ReqUploadProfilePicture
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid UserId { get; set; }
    }
}
