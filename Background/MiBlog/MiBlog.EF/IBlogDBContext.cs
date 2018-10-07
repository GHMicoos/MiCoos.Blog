using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiBlog.EF
{
    public interface IBlogDBContext
    {
        Task SaveAsync();

        int Save();

        BlogDBContext GetCurDbContext();
    }
}
