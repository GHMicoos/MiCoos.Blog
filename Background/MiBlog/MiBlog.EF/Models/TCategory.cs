using System;
using System.Collections.Generic;

namespace MiBlog.EF.Models
{
    public partial class TCategory
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public long State { get; set; }
        public string Creator { get; set; }
        public long CreateTime { get; set; }
    }
}
