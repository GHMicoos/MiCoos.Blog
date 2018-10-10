using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.ViewModel;
using MiBlog.Abstraction.ViewModel.Blog;
using MiBlog.Api;
using MiBlog.EF.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static MiBlog.Abstraction.AutoMapper.BlogProfile;

namespace MiBlog.API
{
    /// <summary>
    /// 博客管理
    /// </summary>
    [Route("[controller]")]
    [EnableCors("AllowCors")]
    public class BlogController: BasicController
    {
        private IBlogService _service;

        public BlogController(IBlogService service, IConfiguration config) : base(config, service)
        {
            _service = service;
        }

        /// <summary>
        /// 查询文章详细信息
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryArticleDetailInfo")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<RespArticleDetailInfo>))]
        public IActionResult QueryArticleDetailInfo(Guid param)
        {
            var result = new ResponseBase<RespArticleDetailInfo>();
            try
            {
                var data = _service.QueryArticleDetailInfo(param);//调用逻辑层
                if (data!= null) SetResultWhenSuccess<RespArticleDetailInfo>(result, data);
                else SetResultWhenFail<RespArticleDetailInfo>(result, data);
            }
            catch (Exception e)
            {
                SetResultWhenError<RespArticleDetailInfo>(result, e);
            }

            return new JsonResult(result);
        }



       
    }
}
