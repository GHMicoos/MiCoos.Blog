using MiBlog.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiBlog.EF
{
    public interface IBlogDBContext
    {
        DbSet<TArticle> TArticle { get; set; }
        DbSet<TCategory> TCategory { get; set; }
        DbSet<TCategoryArticle> TCategoryArticle { get; set; }
        DbSet<TComment> TComment { get; set; }
        DbSet<TLabel> TLabel { get; set; }
        DbSet<TLabelArticle> TLabelArticle { get; set; }
        DbSet<TLoginInfo> TLoginInfo { get; set; }
        DbSet<TUserInfo> TUserInfo { get; set; }


        Task SaveAsync();

        int Save();

        BlogDBContext GetCurDbContext();
    }
}
