using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TComment
    {
        public string CommentId { get; set; }
        public string CommentText { get; set; }
        public string FatherId { get; set; }
        public long FatherType { get; set; }
        public string Creator { get; set; }
        public long CreateTime { get; set; }
        public long State { get; set; }
    }
}
