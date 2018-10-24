using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.User
{
    /// <summary>
    /// 返回结果：贴图库返回结果 异常
    /// </summary>
    public class RespTieTuKuError
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 错误提示
        /// </summary>
        public string info { get; set; }
    }
}
