using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MiBlog.EF.Models
{
    public partial class blogContext : DbContext
    {
        public blogContext()
        {
        }

        public blogContext(DbContextOptions<blogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TArticle> TArticle { get; set; }
        public virtual DbSet<TCategory> TCategory { get; set; }
        public virtual DbSet<TCategoryArticle> TCategoryArticle { get; set; }
        public virtual DbSet<TComment> TComment { get; set; }
        public virtual DbSet<TLabel> TLabel { get; set; }
        public virtual DbSet<TLabelArticle> TLabelArticle { get; set; }
        public virtual DbSet<TLoginInfo> TLoginInfo { get; set; }
        public virtual DbSet<TUserInfo> TUserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("DataSource=D:\\0-leiling\\5-github\\MiCoos.Blog\\DataBase\\blog.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TArticle>(entity =>
            {
                entity.HasKey(e => e.ArticleId);

                entity.ToTable("T_Article");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("ArticleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Author).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.TArticle)
                    .HasForeignKey(d => d.Author);
            });

            modelBuilder.Entity<TCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("T_Category");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Creator).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.TCategory)
                    .HasForeignKey(d => d.Creator);
            });

            modelBuilder.Entity<TCategoryArticle>(entity =>
            {
                entity.HasKey(e => e.ArticleCategoryId);

                entity.ToTable("T_CategoryArticle");

                entity.Property(e => e.ArticleCategoryId)
                    .HasColumnName("ArticleCategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArticleId)
                    .IsRequired()
                    .HasColumnName("ArticleID");

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasColumnName("CategoryID");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.TCategoryArticle)
                    .HasForeignKey(d => d.ArticleId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TCategoryArticle)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<TComment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.ToTable("T_Comment");

                entity.Property(e => e.CommentId)
                    .HasColumnName("CommentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArticleId)
                    .IsRequired()
                    .HasColumnName("ArticleID");

                entity.Property(e => e.CommentText).IsRequired();

                entity.Property(e => e.Creator).IsRequired();

                entity.Property(e => e.FatherCommentId).HasColumnName("FatherCommentID");

                entity.Property(e => e.RootCommentId).HasColumnName("RootCommentID");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.TComment)
                    .HasForeignKey(d => d.ArticleId);

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.TComment)
                    .HasForeignKey(d => d.Creator);

                entity.HasOne(d => d.FatherComment)
                    .WithMany(p => p.InverseFatherComment)
                    .HasForeignKey(d => d.FatherCommentId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.RootComment)
                    .WithMany(p => p.InverseRootComment)
                    .HasForeignKey(d => d.RootCommentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TLabel>(entity =>
            {
                entity.HasKey(e => e.LabelId);

                entity.ToTable("T_Label");

                entity.Property(e => e.LabelId)
                    .HasColumnName("LabelID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Creator).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.TLabel)
                    .HasForeignKey(d => d.Creator);
            });

            modelBuilder.Entity<TLabelArticle>(entity =>
            {
                entity.HasKey(e => e.LabelArticleId);

                entity.ToTable("T_LabelArticle");

                entity.Property(e => e.LabelArticleId)
                    .HasColumnName("LabelArticleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArticleId)
                    .IsRequired()
                    .HasColumnName("ArticleID");

                entity.Property(e => e.LabelId)
                    .IsRequired()
                    .HasColumnName("LabelID");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.TLabelArticle)
                    .HasForeignKey(d => d.ArticleId);

                entity.HasOne(d => d.Label)
                    .WithMany(p => p.TLabelArticle)
                    .HasForeignKey(d => d.LabelId);
            });

            modelBuilder.Entity<TLoginInfo>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.ToTable("T_LoginInfo");

                entity.Property(e => e.LoginId)
                    .HasColumnName("LoginID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID");

                entity.Property(e => e.UserName).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TLoginInfo)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<TUserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("T_UserInfo");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();
            });
        }
    }
}
