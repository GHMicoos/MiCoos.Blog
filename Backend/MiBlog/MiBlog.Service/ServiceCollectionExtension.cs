using System;
using System.Collections.Generic;
using System.Text;
using MiBlog.Abstraction.Interface.Service;
using Microsoft.Extensions.DependencyInjection;

namespace MiBlog.Service
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddService(this IServiceCollection service)
        {
            service.AddTransient<IBaseService, BaseService>();
            service.AddTransient<IBlogService, BlogService>();
            service.AddTransient<IUsreInfoService, UsreInfoService>();
            service.AddTransient<ILabelService, LabelService>();
            service.AddTransient<ICategoryService, CategoryService>();

            return service;
        }
    }
}
