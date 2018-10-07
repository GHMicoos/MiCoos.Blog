using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TLabel
    {
        public byte[] LabelId { get; set; }
        public string Name { get; set; }
        public long State { get; set; }
        public long Creator { get; set; }
        public long CreateTime { get; set; }
    }
}
