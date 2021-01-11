using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPIDecor.Models;

namespace WebAPIDecor.Models
{
    public partial class decorContext : DbContext
    {
        public decorContext()
        {
        }

        public decorContext(DbContextOptions<decorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Poster> Poster { get; set; }
        public virtual DbSet<PosterCategory> PosterCategory { get; set; }
        public virtual DbSet<WallpaperCategory> WallpaperCategory { get; set; }
        public virtual DbSet<WallpaperJournal> WallpaperJournal { get; set; }
        public virtual DbSet<WallpeparJournalItem> WallpeparJournalItem { get; set; }

        public virtual DbSet<JournalswithCategoryTitle> JournalswithCategoryTitles { get; set; }
        public virtual DbSet<User> User { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {

//               // services.Configure<DbConnectionInfo>(settings => configuration.GetSection("ConnectionStrings").Bind(settings));

//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=decor;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JournalswithCategoryTitle>(entity =>
            {

                entity.HasNoKey();
                entity.ToView("JournalswithCategoryTitle");
             
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brand)
                    .HasColumnName("brand")
                    .HasMaxLength(100);

                entity.Property(e => e.CategoryTitle)
                .HasColumnName("CategoryTitle")
                .HasMaxLength(200);

                entity.Property(e => e.Describtion)
                    .HasColumnName("describtion")
                    .HasMaxLength(500);



                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(100);
            }

            );
            modelBuilder.Entity<Poster>(entity =>
            {
                entity.ToTable("poster");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.ImgUrl)
                    .HasColumnName("imgURL")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<PosterCategory>(entity =>
            {
                entity.ToTable("poster_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Describtion)
                    .HasColumnName("describtion")
                    .HasMaxLength(500);

                entity.Property(e => e.ImgUrl)
                    .HasColumnName("imgURL")
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<WallpaperCategory>(entity =>
            {
                entity.ToTable("wallpaper_category");

                entity.Property(e => e.Id).HasColumnName("id");

                

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200);

                entity.Property(e => e.ImageURL)
                    .HasColumnName("imgURL")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<WallpaperJournal>(entity =>
            {
                entity.ToTable("wallpaper_journal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brand)
                    .HasColumnName("brand")
                    .HasMaxLength(100);

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Describtion)
                    .HasColumnName("describtion")
                    .HasMaxLength(500);

               

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                       .HasColumnName("email")
                       .HasMaxLength(100);


                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);



     
            });


            modelBuilder.Entity<WallpeparJournalItem>(entity =>
            {
                entity.ToTable("wallpepar_journal_item");

                entity.Property(e => e.Id).HasColumnName("id");

               
                entity.Property(e => e.WallpaperJournalId).HasColumnName("wallpaperJournalID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
