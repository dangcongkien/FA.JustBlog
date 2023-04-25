using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Configs
{
    public class CommentsConfig : IEntityTypeConfiguration<Comments>
    {
        /// <summary>
        /// Config primarykey and foreignkey for Comments
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.CommentId);

            builder.HasOne(p => p.Posts)
                    .WithMany(c => c.Comments)
                    .HasForeignKey(p => p.PostId);
        }
    }
}
