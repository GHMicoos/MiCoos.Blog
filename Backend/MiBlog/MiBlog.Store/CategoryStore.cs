using MiBlog.Abstraction.Interface.Store;
using MiBlog.EF;
using MiBlog.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiBlog.Store
{
    public class CategoryStore: ICategoryStore
    {
        private readonly IConfiguration _config;
        private readonly IBlogDBContext _dbContext;

        public CategoryStore(IConfiguration config, IBlogDBContext dbContext)
        {
            _config = config;
            _dbContext = dbContext;
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddCategory(TCategory data)
        {
            _dbContext.TCategory.Add(data);
            _dbContext.Save();
            return true;
        }

        /// <summary>
        /// 查询分类
        /// </summary>
        /// <returns></returns>
        public IQueryable<TCategory> QueryCategory()
            => _dbContext.TCategory.AsNoTracking();
    }
}
