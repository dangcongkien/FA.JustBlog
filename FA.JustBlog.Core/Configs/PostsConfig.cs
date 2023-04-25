using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Configs
{
    public class PostsConfig : IEntityTypeConfiguration<Posts>
    {
        /// <summary>
        /// Config primakey and foreignkey for Posts
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.PostId);

            builder.HasOne(p => p.Categories)
                    .WithMany(c => c.Posts)
                    .HasForeignKey(p => p.CategoryId);
        }
    }
}
