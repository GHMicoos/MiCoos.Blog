using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TLabelArticle
    {
        public byte[] LabelArticleId { get; set; }
        public byte[] ArticleId { get; set; }
        public byte[] LabelId { get; set; }
    }
}
