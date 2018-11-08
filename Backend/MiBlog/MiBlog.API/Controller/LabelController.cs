﻿using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.ViewModel.Label;
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
    /// 标签管理
    /// </summary>
    [Route("[controller]")]
    [EnableCors("any")]
    public class LabelController: BasicController
    {
        private ILabelService _service;
        private IConfiguration _config;

        public LabelController(ILabelService service, IConfiguration config) : base(config, service)
        {
            _service = service;
            _config = config;
        }

        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddLabel")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<bool>))]
        public IActionResult AddLabel([FromBody]ReqAddLabel param)
        {
            var result = new ResponseBase<bool>();
            try
            {
                var data = _service.AddLabel(param);//调用逻辑层
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