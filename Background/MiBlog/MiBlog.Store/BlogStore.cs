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
    public class BlogStore : IBlogStore
    {
        private readonly IConfiguration _config;
        private readonly IBlogDBContext _dbContext;

        public BlogStore(IConfiguration config, IBlogDBContext dbContext)
        {
            _config = config;
            _dbContext = dbContext;
        }

        public IQueryable<TUserInfo> QueryUserInfo()
            => _dbContext.TUserInfo.AsNoTracking();
    }
}
