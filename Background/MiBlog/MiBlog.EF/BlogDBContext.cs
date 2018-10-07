using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiBlog.EF
{
    public class BlogDBContext : DbContext, IBlogDBContext
    {

        public BlogDBContext(DbContextOptions<BlogDBContext> options)
           : base(options)
        {
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //base.Database.AutoTransactionsEnabled = false;
            //base.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public BlogDBContext GetCurDbContext()
            => this;

        public int Save()
            => this.SaveChanges();

        public Task SaveAsync()
            => this.SaveChangesAsync();
    }
}
