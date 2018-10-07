using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TArticle
    {
        public byte[] ArticleId { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public byte[] Author { get; set; }
        public long State { get; set; }
        public long CreateTime { get; set; }
        public long? PublistTime { get; set; }

        public TUserInfo AuthorNavigation { get; set; }
    }
}
