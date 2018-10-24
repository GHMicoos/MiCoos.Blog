using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TCategory
    {
        public TCategory()
        {
            TCategoryArticle = new HashSet<TCategoryArticle>();
        }

        public string CategoryId { get; set; }
        public string Name { get; set; }
        public long IsDelete { get; set; }
        public string Creator { get; set; }
        public long CreateTime { get; set; }

        public TUserInfo CreatorNavigation { get; set; }
        public ICollection<TCategoryArticle> TCategoryArticle { get; set; }
    }
}
