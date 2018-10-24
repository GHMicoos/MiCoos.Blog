using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiBlog.Host.Swagger
{
    public class SwaggerFileUploadFilter: IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (!context.ApiDescription.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase) &&
                !context.ApiDescription.HttpMethod.Equals("PUT", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var fileParameters = context.ApiDescription.ActionDescriptor.Parameters.Where(n => n.ParameterType == typeof(IFormFile)).ToList();

            if (fileParameters.Count < 0)
            {
                return;
            }

            if (context.ApiDescription.ParameterDescriptions.Any(x => x.ModelMetadata.ContainerType == typeof(IFormFile)))
            {
                operation.Parameters.Clear();
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "file", // must match parameter name from controller method
                    In = "formData",
                    Description = "上传文件",
                    Required = true,
                    Type = "file"
                });
                operation.Consumes.Add("application/form-data");
            }
        }
    }
}
