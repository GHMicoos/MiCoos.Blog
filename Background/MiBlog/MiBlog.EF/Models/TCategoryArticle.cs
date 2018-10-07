using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TCategoryArticle
    {
        public byte[] ArticleCategoryId { get; set; }
        public byte[] ArticleId { get; set; }
        public byte[] CategoryId { get; set; }
    }
}
