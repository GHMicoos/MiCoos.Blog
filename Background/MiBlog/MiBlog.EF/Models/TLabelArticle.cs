using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TLabelArticle
    {
        public string LabelArticleId { get; set; }
        public string ArticleId { get; set; }
        public string LabelId { get; set; }

        public TArticle Article { get; set; }
        public TLabel Label { get; set; }
    }
}
