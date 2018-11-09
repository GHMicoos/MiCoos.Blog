using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.ViewModel.Category;
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
    public class CategoryController: BasicController
    {

        private ICategoryService _service;
        private IConfiguration _config;

        public CategoryController(ICategoryService service, IConfiguration config) : base(config, service)
        {
            _service = service;
            _config = config;
        }

        /// <summary>
        /// 新增分类
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCategory")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<bool>))]
        public IActionResult AddCategory([FromBody]ReqAddCategory param)
        {
            var result = new ResponseBase<bool>();
            try
            {
                var data = _service.AddCategory(param);//调用逻辑层
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
        /// 删除分类 当分类没有文章关联
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteCategoryIfNoArticle")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<bool>))]
        public IActionResult DeleteCategoryIfNoArticle([FromBody]ReqAddCategory param)
        {
            var result = new ResponseBase<bool>();
            try
            {
                var data = _service.DeleteCategoryIfNoArticle(param);//调用逻辑层
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
        /// 查询标签名称列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryCategory")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<List<string>>))]
        public IActionResult QueryCategory()
        {
            var result = new ResponseBase<List<string>>();
            try
            {
                var data = _service.QueryCategory();//调用逻辑层
                if (data.Count > 0) SetResultWhenSuccess<List<string>>(result, data);
                else SetResultWhenFail<List<string>>(result, data);
            }
            catch (Exception e)
            {
                SetResultWhenError<List<string>>(result, e);
            }

            return new JsonResult(result);
        }
    }
}
