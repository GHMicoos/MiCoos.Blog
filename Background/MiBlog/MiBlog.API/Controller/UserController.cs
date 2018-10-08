using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.ViewModel;
using MiBlog.Api;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MiBlog.API.Controller
{

    /// <summary>
    /// 博客管理
    /// </summary>
    [Route("[controller]")]
    [EnableCors("AllowCors")]
    public class UserController : BasicController
    {
        private IUsreInfoService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="config"></param>
        public UserController(IUsreInfoService service, IConfiguration config) : base(config, service)
        {
            _service = service;
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryUserInfo")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<IList<RespQueryUserInfo>>))]
        public IActionResult QueryUserInfo(ReqQueryUserInfo param)
        {
            var result = new ResponseBase<IList<RespQueryUserInfo>>();
            try
            {
                var data = _service.QueryUserInfo(param);
                if (data?.Count >= 0)
                {
                    SetResultWhenSuccess<IList<RespQueryUserInfo>>(result, data);
                    result.RecordCount = data.Count;
                }
                else SetResultWhenFail<IList<RespQueryUserInfo>>(result, data);
            }
            catch (Exception e)
            {
                SetResultWhenError<IList<RespQueryUserInfo>>(result, e);
            }

            return new JsonResult(result);
        }
       
    }
    
}
