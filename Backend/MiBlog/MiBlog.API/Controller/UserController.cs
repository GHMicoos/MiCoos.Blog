using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using MiBlog.Abstraction.ViewModel;
using MiBlog.Abstraction.ViewModel.User;
using MiBlog.Api;
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
using System.Threading.Tasks;

namespace MiBlog.API.Controller
{

    /// <summary>
    /// 博客管理
    /// </summary>
    [Route("[controller]")]
    [EnableCors("any")]
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

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UploadProfilePicture")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBase<bool>))]
        public IActionResult UploadProfilePicture(Guid userId, IFormFile file)
        {
            var result = new ResponseBase<bool>();
            try
            {
                var saveRootPath = _config.GetSection("UploadPath:Image").Value;
                var saveFileName =$"{DateTime.Now:yyyyMMddHHmmss}_{file.FileName}";
                var savePath =$"{saveRootPath}\\{saveFileName}";

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
                    SetResultWhenFail<bool>(result, false,$"{errorTieTuKu.code},{errorTieTuKu.info}");
                }
                else
                {
                    var tieTuKu = JsonConvert.DeserializeObject<RespTieTuKu>(content);
                    if(tieTuKu==null || tieTuKu.linkurl.IsNullOrWhiteSpace())
                        SetResultWhenFail<bool>(result, false);
                    var saveResult=_service.UpdateUserInfo(new ReqUpdateUserInfo()
                    {
                        UserId = userId,
                        ProfilePicture = tieTuKu.linkurl,
                    });
                    if(saveResult) SetResultWhenSuccess<bool>(result, true);
                    else SetResultWhenFail<bool>(result, false);
                }

                var deleteFile = new FileInfo(savePath);
                deleteFile.Delete();
                
            }
            catch (Exception e)
            {
                SetResultWhenError<bool>(result, e);
            }

            return new JsonResult(result);
        }
    }
    
}
