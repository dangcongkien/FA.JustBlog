using FA.JustBlog.Core.Configs;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.DataContext
{
    public class JustBlogContext : DbContext
    {
        public JustBlogContext()
        {

        }

        public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostsConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoriesConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TagsConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostTagMapConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommentsConfig).Assembly);
            modelBuilder.SeedData();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=JustBlogDB1;Trusted_Connection=True;TrustServerCertificate=True");

            }
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }
        public DbSet<Comments> Comments { get; set; }


    }
}
