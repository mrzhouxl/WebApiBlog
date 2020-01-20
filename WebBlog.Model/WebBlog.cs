namespace WebBlog.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebBlog : DbContext
    {
        public WebBlog()
            : base("name=WebBlog")
        {
        }

        public virtual DbSet<blg_article> blg_article { get; set; }
        public virtual DbSet<blg_article_tag> blg_article_tag { get; set; }
        public virtual DbSet<blg_Category> blg_Category { get; set; }
        public virtual DbSet<blg_tag> blg_tag { get; set; }
        public virtual DbSet<blg_user> blg_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<blg_article>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<blg_article>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<blg_article>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<blg_article>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<blg_article>()
                .HasMany(e => e.blg_article_tag)
                .WithOptional(e => e.blg_article)
                .HasForeignKey(e => e.artucleId);

            modelBuilder.Entity<blg_Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<blg_Category>()
                .Property(e => e.Introduce)
                .IsUnicode(false);

            modelBuilder.Entity<blg_tag>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<blg_tag>()
                .HasMany(e => e.blg_article_tag)
                .WithOptional(e => e.blg_tag)
                .HasForeignKey(e => e.tagId);

            modelBuilder.Entity<blg_user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<blg_user>()
                .Property(e => e.pictureImg)
                .IsUnicode(false);

            modelBuilder.Entity<blg_user>()
                .Property(e => e.introduce)
                .IsUnicode(false);

            modelBuilder.Entity<blg_user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<blg_user>()
                .HasMany(e => e.blg_article)
                .WithOptional(e => e.blg_user)
                .HasForeignKey(e => e.UserId);
        }
    }
}
