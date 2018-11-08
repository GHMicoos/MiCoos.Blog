using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MiBlog.Host.Swagger;
using MiBlog.Service;
using MiBlog.Store;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MiBlog
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStoreEntityFrameworkSqlServer(@"DataSource=D:\0-leiling\5-github\MiCoos.Blog\DataBase\blog.db");
            services.AddService();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "blog 接口文档",
                    Version = "v1",
                    Description = "blog HTTP API",
                    TermsOfService = "Terms Of Service"
                });
                var basePath = Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = System.IO.Path.Combine(basePath, "MiBlog.API.xml");
                var xmlPahtModle = System.IO.Path.Combine(basePath, "MiBlog.Abstraction.xml");
                options.IncludeXmlComments(xmlPath);
                options.IncludeXmlComments(xmlPahtModle);
                options.OperationFilter<SwaggerFileUploadFilter>();
                //options.OperationFilter<SwaggerHttpHeaderFilter>();

            });

            // 配置跨域处理
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie
                });
            });

            services.AddMvc();

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add<HttpGlobalExceptionFilter>();
            //}).AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //});

            //添加对象映射
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();
            app.UseCors("any");
            //app.UseCors("AllowCors");

            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API V1");

            });
        }
    }
}
