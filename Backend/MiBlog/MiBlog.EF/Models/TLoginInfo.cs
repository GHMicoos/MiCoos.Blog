using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TLoginInfo
    {
        public string LoginId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long State { get; set; }

        public TUserInfo User { get; set; }
    }
}
