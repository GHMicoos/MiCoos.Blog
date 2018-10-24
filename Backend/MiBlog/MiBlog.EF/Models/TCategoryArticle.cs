using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TCategoryArticle
    {
        public string ArticleCategoryId { get; set; }
        public string ArticleId { get; set; }
        public string CategoryId { get; set; }

        public TArticle Article { get; set; }
        public TCategory Category { get; set; }
    }
}
