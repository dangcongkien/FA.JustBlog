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
    public class PostTagMapConfig : IEntityTypeConfiguration<PostTagMap>
    {
        /// <summary>
        /// Config primakey and foreignkey for PostTagMap
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<PostTagMap> builder)
        {
            builder.ToTable("PostTagMap");
            builder.HasKey(pt => new { pt.PostId, pt.TagId });

            builder.HasOne(pt => pt.Posts)
                .WithMany(p => p.PostTagMaps)
                .HasForeignKey(pt => pt.PostId);

            builder.HasOne(pt => pt.Tags)
                .WithMany(t => t.PostTagMaps)
                .HasForeignKey(pt => pt.TagId);
        }
    }
}
