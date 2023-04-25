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
    public class CategoriesConfig : IEntityTypeConfiguration<Categories>
    {
        /// <summary>
        /// Config Primakey for Categories
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.CategoryId);
        }
    }
}
