using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TArticle
    {
        public TArticle()
        {
            TCategoryArticle = new HashSet<TCategoryArticle>();
            TComment = new HashSet<TComment>();
            TLabelArticle = new HashSet<TLabelArticle>();
        }

        public string ArticleId { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string Author { get; set; }
        public long State { get; set; }
        public long CreateTime { get; set; }
        public long? PublistTime { get; set; }

        public TUserInfo AuthorNavigation { get; set; }
        public ICollection<TCategoryArticle> TCategoryArticle { get; set; }
        public ICollection<TComment> TComment { get; set; }
        public ICollection<TLabelArticle> TLabelArticle { get; set; }
    }
}
