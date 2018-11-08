using MiBlog.Abstraction.Interface.Store;
using MiBlog.EF;
using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<BlogDBContext>(options =>options.UseSqlite(sqlConnection));
            services.AddTransient<IBlogDBContext, BlogDBContext>();

            services.AddTransient<IBlogStore, BlogStore>();
            services.AddTransient<IUserInfoStore, UserInfoStore>();
            services.AddTransient<ILabelStore, LabelStore>();
            services.AddTransient<ICategoryStore, CategoryStore>();

            return services;
        }
    }
}
