using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.ViewModel;
using MiBlog.Abstraction.ViewModel.Blog;
using MiBlog.Abstraction.ViewModel.User;
using MiBlog.Api;
using MiBlog.EF.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private IConfiguration _config;

        public BlogController(IBlogService service, IConfiguration config) : base(config, service)
        {
            _service = service;
            _config = config;
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
        [Route("QueryUserArticleStatistic")]
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
        /// 上传图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UploadPicture")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        public IActionResult UploadPicture(IFormFile file)
        {
            var result = new ResponseBase<string>();
            try
            {
                var saveRootPath = _config.GetSection("UploadPath:Image").Value;
                var saveFileName = $"{DateTime.Now:yyyyMMddHHmmss}_{file.FileName}";
                var savePath = $"{saveRootPath}\\{saveFileName}";

                if (!Directory.Exists(saveRootPath))
                {
                    Directory.CreateDirectory(saveRootPath);
                }
                using (FileStream fs = new FileStream(savePath, FileMode.OpenOrCreate))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                var url = _config.GetSection("TieTuKu:BaseUrl").Value;
                var token = _config.GetSection("TieTuKu:Token").Value;

                //var retData = new ResponseBase<RespHomePageReportData>();
                var fileName = savePath.Split("\\").ToList().Last();
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest("", RestSharp.Method.POST);
                //request.AddHeader("accept", "application/json");
                //request.AddHeader("Content-Type", "application/json-patch+json");
                var param = new { Token = token };
                request.AddParameter("Token", token);
                request.AddFile("file", savePath);
                RestSharp.IRestResponse response = client.Execute(request);
                var content = response.Content;

                if (content.Contains("code") && content.Contains("info"))
                {
                    var errorTieTuKu = JsonConvert.DeserializeObject<RespTieTuKuError>(content);
                    SetResultWhenFail<string>(result, string.Empty, $"{errorTieTuKu.code},{errorTieTuKu.info}");
                }
                else
                {
                    var tieTuKu = JsonConvert.DeserializeObject<RespTieTuKu>(content);
                    if (tieTuKu == null || tieTuKu.linkurl.IsNullOrWhiteSpace())
                        SetResultWhenFail<string>(result, tieTuKu.linkurl);
                    else
                        SetResultWhenSuccess<string>(result, tieTuKu.linkurl);
                }

                var deleteFile = new FileInfo(savePath);
                deleteFile.Delete();

            }
            catch (Exception e)
            {
                SetResultWhenError<string>(result, e);
            }

            return new JsonResult(new { result.Data });
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
        //    }

    }
}
