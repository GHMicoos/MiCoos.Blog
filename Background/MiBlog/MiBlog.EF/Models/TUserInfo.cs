using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TUserInfo
    {
        public TUserInfo()
        {
            TArticle = new HashSet<TArticle>();
            TCategory = new HashSet<TCategory>();
            TLabel = new HashSet<TLabel>();
            TLoginInfo = new HashSet<TLoginInfo>();
        }

        public string UserId { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public long? Birthday { get; set; }
        public long RegistTime { get; set; }

        public ICollection<TArticle> TArticle { get; set; }
        public ICollection<TCategory> TCategory { get; set; }
        public ICollection<TLabel> TLabel { get; set; }
        public ICollection<TLoginInfo> TLoginInfo { get; set; }
    }
}
