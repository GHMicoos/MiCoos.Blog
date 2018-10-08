using MiBlog.Abstraction.Common;
using MiBlog.Abstraction.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;

namespace MiBlog.Api
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    public class BasicController: Controller
    {
        private IConfiguration _config;
        private IBaseService _baseService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="service"></param>
        public BasicController(IConfiguration config, IBaseService service)
        {
            _config = config;
            _baseService = service;
        }

        /// <summary>
        /// 设置服务层属性
        /// </summary>
        protected void SetService()
        {
            //_baseService.Token = Token;
            //_baseService.Account = UserAccount;
            //_baseService.UserRoles = UserRoles;
            //_baseService.MainDept = MainDept;
            //_baseService.Name = UserName;
        }

        /// <summary>
        /// 检查传入参数
        /// </summary>
        /// <returns></returns>
        protected string CheckIsVaild()
        {
            var result = default(string);
            if (!ModelState.IsValid)
            {
                result = string.Empty;
                foreach (var item in ModelState.Values)
                {
                    foreach (var jitem in item.Errors)
                    {
                        result += jitem.ErrorMessage + "|";
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var result = new ResponseBase<object>();
            var vaildString = CheckIsVaild();
            if (!string.IsNullOrWhiteSpace(vaildString))
            {
                result.Status = ResponseStatus.Error;
                result.Message = CommonConstValue.ResponseBase_Message_ParamError + vaildString;
                filterContext.Result = new JsonResult(result);
                return;
            }
            SetService();
        }

        /// <summary>
        /// 设置结果对象，当成功
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="result"></param>
        /// <param name="data"></param>
        public void SetResultWhenSuccess<TData>(ResponseBase<TData> result, TData data)
        {
            result.Status = ResponseStatus.Success;
            result.Data = data;
            result.Message = CommonConstValue.ResponseBase_Message_Success;
        }

        /// <summary>
        /// 设置结果对象，当失败
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="result"></param>
        /// <param name="data"></param>
        public void SetResultWhenFail<TData>(ResponseBase<TData> result, TData data)
        {
            result.Status = ResponseStatus.Fail;
            result.Data = data;
            result.Message = CommonConstValue.ResponseBase_Message_Fail;
        }

        /// <summary>
        /// 设置结果对象，当错误
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="result"></param>
        /// <param name="e"></param>
        public void SetResultWhenError<TData>(ResponseBase<TData> result, Exception e)
        {
            result.Status = ResponseStatus.Error;
            result.Data = default(TData);
            result.Message = CommonConstValue.ResponseBase_Message_Error + e.Message;
        }

    }
}
