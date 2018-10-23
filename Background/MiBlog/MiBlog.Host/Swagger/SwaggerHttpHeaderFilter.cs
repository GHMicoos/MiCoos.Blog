using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiBlog.Host.Swagger
{
    public class SwaggerHttpHeaderFilter: IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }

            var actionAttrs = context.ApiDescription.ActionAttributes();

            var enumerable = actionAttrs.ToList();
            // var isAuthorized = enumerable.Any(a => a.GetType() == typeof(AuthorizeAttribute));

            //if (isAuthorized == false) //提供action都没有权限特性标记，检查控制器有没有
            //{
            //    var controllerAttrs = context.ApiDescription.ControllerAttributes();

            //    isAuthorized = controllerAttrs.Any(a => a.GetType() == typeof(AuthorizeAttribute));
            //}

            var isAllowAnonymous = enumerable.Any(a => a.GetType() == typeof(AllowAnonymousAttribute));
            //isAuthorized && 
            if (isAllowAnonymous == false)
            {
                operation.Parameters.Add(new NonBodyParameter()
                {
                    Name = "Authorization",  //添加Authorization头部参数
                    In = "header",
                    Type = "string",
                    Required = false,
                    Default = "Bearer ",
                    Description = "此处为登录成功后的access_token值，完整格式：Bearer access_token"
                });
            }
        }
    }
}
