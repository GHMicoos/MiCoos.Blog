using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.User
{
    /// <summary>
    /// 返回结果：贴图库上传文件后返回结果
    /// </summary>
    public class RespTieTuKu
    {
        /// <summary>
        /// 图片的宽
        /// </summary>
        public int width { get; set; }

        /// <summary>
        /// 图片的高
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// 图片类型（文件后缀名）
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 图片大小(单位:字节)
        /// </summary>
        public int size { get; set; }

        /// <summary>
        /// 图片UBB引用代码
        /// </summary>
        public int ubburl { get; set; }

        /// <summary>
        /// 图片原图地址
        /// </summary>
        public int linkurl { get; set; }

        /// <summary>
        /// 图片HTML引用代码
        /// </summary>
        public int htmlurl { get; set; }

        /// <summary>
        /// 图片markdown引用代码
        /// </summary>
        public int markdown { get; set; }

        /// <summary>
        /// 图片展示图地址
        /// </summary>
        public int s_url { get; set; }

        /// <summary>
        /// 图片缩略图地址
        /// </summary>
        public int t_url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int findurl { get; set; }
    }
}
