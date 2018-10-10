using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TComment
    {
        public TComment()
        {
            InverseFatherComment = new HashSet<TComment>();
        }

        public string CommentId { get; set; }
        public string CommentText { get; set; }
        public string ArticleId { get; set; }
        public string FatherCommentId { get; set; }
        public string Creator { get; set; }
        public long CreateTime { get; set; }
        public long State { get; set; }

        public TArticle Article { get; set; }
        public TComment FatherComment { get; set; }
        public ICollection<TComment> InverseFatherComment { get; set; }
    }
}
