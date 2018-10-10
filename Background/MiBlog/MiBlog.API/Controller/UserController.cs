using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.ViewModel;
using MiBlog.Abstraction.ViewModel.User;
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
        private IConfiguration _config;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="config"></param>
        public UserController(IUsreInfoService service, IConfiguration config) : base(config, service)
        {
            _service = service;
            _config = config;
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryUserInfo")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<IList<RespUserInfo>>))]
        public IActionResult QueryUserInfo(ReqQueryUserInfo param)
        {
            var result = new ResponseBase<IList<RespUserInfo>>();
            try
            {
                var count = default(int);
                var data = _service.QueryUserInfo(param,out count);
                result.RecordCount = count;
                if (data!=null) SetResultWhenSuccess<IList<RespUserInfo>>(result, data);
                else SetResultWhenFail<IList<RespUserInfo>>(result, data);
            }
            catch (Exception e)
            {
                SetResultWhenError<IList<RespUserInfo>>(result, e);
            }

            return new JsonResult(result);
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("RegistUser")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<bool>))]
        public IActionResult RegistUser(ReqAddLoginInfo param)
        {
            var result = new ResponseBase<bool>();
            try
            {
                var data = _service.RegistUser(param);
                if (data) SetResultWhenSuccess<bool>(result, data);
                else SetResultWhenFail<bool>(result, data);
            }
            catch (Exception e)
            {
                SetResultWhenError<bool>(result, e);
            }

            return new JsonResult(result);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("UpdateUserInfo")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<bool>))]
        public IActionResult UpdateUserInfo(ReqUpdateUserInfo param)
        {
            var result = new ResponseBase<bool>();
            try
            {
                var data = _service.UpdateUserInfo(param);
                if (data) SetResultWhenSuccess<bool>(result, data);
                else SetResultWhenFail<bool>(result, data);
            }
            catch (Exception e)
            {
                SetResultWhenError<bool>(result, e);
            }

            return new JsonResult(result);
        }
    }
    
}
