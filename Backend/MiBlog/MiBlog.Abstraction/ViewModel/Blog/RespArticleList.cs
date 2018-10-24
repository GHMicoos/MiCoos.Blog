using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Abstraction.ViewModel.Blog
{
    /// <summary>
    /// 返回结果：文章列表
    /// </summary>
    public class RespArticleList
    {
        #region 文章相关

        /// <summary>
        /// 
        /// </summary>
        public Guid ArticleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        #endregion
    }
}
