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

        /// <summary>
        /// 查询文章
        /// </summary>
        /// <returns></returns>
        public IQueryable<TArticle> QueryArticle()
            => _dbContext.TArticle.AsNoTracking();

        /// <summary>
        /// 查询 文章标签表
        /// </summary>
        /// <returns></returns>
        public IQueryable<TLabelArticle> QueryLabelArticle()
            => _dbContext.TLabelArticle.AsNoTracking();
        /// <summary>
        /// 查询 评论
        /// </summary>
        /// <returns></returns>
        public IQueryable<TComment> QueryComment()
            => _dbContext.TComment.AsNoTracking();
    }
}
