using MiBlog.Abstraction.ViewModel;
using MiBlog.Abstraction.ViewModel.Blog;
using MiBlog.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MiBlog.Abstraction.AutoMapper.BlogProfile;

namespace MiBlog.Abstraction.Interface.Service
{
    public interface IBlogService: IBaseService
    {
        
        /// <summary>
        /// 查询文章详细信息
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        RespArticleDetailInfo QueryArticleDetailInfo(Guid param);
        
    }
}
