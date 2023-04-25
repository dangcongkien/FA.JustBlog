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
    public class TagsConfig : IEntityTypeConfiguration<Tags>
    {
        /// <summary>
        /// Config primakey for Tags
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Tags> builder)
        {
            builder.ToTable("Tags");
            builder.HasKey(t => t.TagId);
        }
    }
}
