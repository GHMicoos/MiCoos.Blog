using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace MiBlog.Service
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddService(this IServiceCollection service)
        {
            //services.AddTransient<IIntegratedServiceClient, IntegratedServiceClient>();
            return service;
        }
    }
}
