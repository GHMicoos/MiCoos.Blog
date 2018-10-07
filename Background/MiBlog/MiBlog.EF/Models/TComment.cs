using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TComment
    {
        public byte[] CommentId { get; set; }
        public string CommentText { get; set; }
        public byte[] FatherId { get; set; }
        public long FatherType { get; set; }
        public byte[] Creator { get; set; }
        public long CreateTime { get; set; }
        public long State { get; set; }
    }
}
