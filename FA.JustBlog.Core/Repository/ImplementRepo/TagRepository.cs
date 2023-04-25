using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.GenericRepo;
using FA.JustBlog.Core.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository.ImplementRepo
{
    public class TagRepository : GenericRepository<Tags>, ITagRepository
    {
        public TagRepository(JustBlogContext context = null) : base(context)
        {
        }

        /// <summary>
        /// Function Get Tag By UrlSlug
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        public Tags GetTagByUrlSlug(string urlSlug)
        {
            return context.Tags.FirstOrDefault(t => t.UrlSlug == urlSlug);
        }
    }
}
