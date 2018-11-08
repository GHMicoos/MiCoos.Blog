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
    public class LabelStore: ILabelStore
    {
        private readonly IConfiguration _config;
        private readonly IBlogDBContext _dbContext;

        public LabelStore(IConfiguration config, IBlogDBContext dbContext)
        {
            _config = config;
            _dbContext = dbContext;
        }

        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddLabel(TLabel data)
        {
            _dbContext.TLabel.Add(data);
            _dbContext.Save();
            return true;
        }

        /// <summary>
        /// 查询标签
        /// </summary>
        /// <returns></returns>
        public IQueryable<TLabel> QueryLabel()
            => _dbContext.TLabel.AsNoTracking();
    }
}
