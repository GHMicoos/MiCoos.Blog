using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.ViewModel;
using MiBlog.Api;
using MiBlog.EF.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

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
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryUserInfo")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<List<RespQueryUserInfo>>))]
        public IActionResult QueryUserInfo([FromForm]ReqQueryUserInfo param)
            //=> new JsonResult(CallService<ReqQueryUserInfo, List<RespQueryUserInfo>>(param, _service.QueryUserInfo));
        => new JsonResult(_service.QueryUserInfo());
    }
}
