using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    public class RespLabel
    {
        /// <summary>
        /// 标签id
        /// </summary>
        public Guid LabelId { get; set; }

        /// <summary>
        /// 标签名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public Guid Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
