using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TLabel
    {
        public TLabel()
        {
            TLabelArticle = new HashSet<TLabelArticle>();
        }

        public string LabelId { get; set; }
        public string Name { get; set; }
        public long IsDelete { get; set; }
        public string Creator { get; set; }
        public long CreateTime { get; set; }

        public TUserInfo CreatorNavigation { get; set; }
        public ICollection<TLabelArticle> TLabelArticle { get; set; }
    }
}
