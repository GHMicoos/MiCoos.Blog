using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiBlog.Store
{
    public static class StoreCollectionExtension
    {
        public static IServiceCollection AddStoreEntityFrameworkSqlServer(
            this IServiceCollection services,
            string sqlConnection
        )
        {
            //services.AddDbContext<CrmDbContext>(options =>options.UseSqlServer(sqlConnection));
            //services.AddTransient<ICustomerPoolStore, CustomerPoolStore>();

            return services;
        }
    }
}
