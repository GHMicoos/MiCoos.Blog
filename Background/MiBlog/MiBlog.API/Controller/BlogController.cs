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
    //[EnableCors("AllowCors")]
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

        /// <summary>
        /// 查询文章评论信息
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryArticleCommentDetailInfo")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<RespArticleCommentDetailInfo>))]
        public IActionResult QueryArticleCommentDetailInfo(ReqArticleCommentDetailInfo param)
        {
            var result = new ResponseBase<RespArticleCommentDetailInfo>();
            try
            {
                var data = _service.QueryArticleCommentDetailInfo(param);//调用逻辑层
                if (data != null) SetResultWhenSuccess<RespArticleCommentDetailInfo>(result, data);
                else SetResultWhenFail<RespArticleCommentDetailInfo>(result, data);
            }
            catch (Exception e)
            {
                SetResultWhenError<RespArticleCommentDetailInfo>(result, e);
            }

            return new JsonResult(result);
        }

        /// <summary>
        /// 查询用户的文章榜单 推荐/阅读/热评
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryUserArticleRank")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<UserArticleRank>))]
        public IActionResult QueryUserArticleRank(Guid param)
        {
            var result = new ResponseBase<UserArticleRank>();
            try
            {
                var data = _service.QueryUserArticleRank(param);//调用逻辑层
                if (data != null) SetResultWhenSuccess<UserArticleRank>(result, data);
                else SetResultWhenFail<UserArticleRank>(result, data);
            }
            catch (Exception e)
            {
                SetResultWhenError<UserArticleRank>(result, e);
            }

            return new JsonResult(result);
        }

        /// <summary>
        /// 查询用户的文章统计
        /// 1.榜单
        /// 2.用户文章 分类统计
        /// 3.用户文章 标签统计
        /// 4.用户文章 时间统计
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryUserArticleRank")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<RespUserArticleStatistic>))]
        public IActionResult QueryUserArticleStatistic(Guid param)
        {
            var result = new ResponseBase<RespUserArticleStatistic>();
            try
            {
                var data = _service.QueryUserArticleStatistic(param);//调用逻辑层
                if (data != null) SetResultWhenSuccess<RespUserArticleStatistic>(result, data);
                else SetResultWhenFail<RespUserArticleStatistic>(result, data);
            }
            catch (Exception e)
            {
                SetResultWhenError<RespUserArticleStatistic>(result, e);
            }

            return new JsonResult(result);
        }


        /// <summary>
        /// 查询用户的文章列表
        /// </summary>
        /// <param name="param">文章id</param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("QueryUserArticleRank")]
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<RespUserArticleStatistic>))]
        //public IActionResult QueryUserArticleList(ReqUserArticleList param)
        //{
        //    var result = new ResponseBase<RespUserArticleStatistic>();
        //    try
        //    {
        //        var data = _service.QueryUserArticleList(param);//调用逻辑层
        //        if (data != null) SetResultWhenSuccess<RespUserArticleStatistic>(result, data);
        //        else SetResultWhenFail<RespUserArticleStatistic>(result, data);
        //    }
        //    catch (Exception e)
        //    {
        //        SetResultWhenError<RespUserArticleStatistic>(result, e);
        //    }

        //    return new JsonResult(result);
        //}

    }
}
