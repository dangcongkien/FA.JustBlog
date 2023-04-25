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
    public class PostRepository : GenericRepository<Posts>, IPostRepository
    {
        public PostRepository(JustBlogContext context = null) : base(context)
        {
        }

        /// <summary>
        /// Funstion Count Posts For Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int CountPostsForCategory(string category)
        {
            return context.Posts.Count(c => c.Categories.Name == category);
        }

        /// <summary>
        /// Function Find Post
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        public Posts FindPost(int year, int month, string urlSlug)
        {
            return context.Posts.FirstOrDefault(c => c.PostedOn.Year == year && 
                                                c.PostedOn.Month == month && 
                                                c.UrlSlug == urlSlug);
        }

        /// <summary>
        /// Function Get Highest Posts
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public IList<Posts> GetHighestPosts(int size)
        {
            var posts = context.Posts.Where(p => p.Published).ToList();

            posts.Sort((p1, p2) => p2.Rate.CompareTo(p1.Rate));

            return posts.Take(size).ToList();
        }

        /// <summary>
        /// Function Get Latest Post
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public IList<Posts> GetLatestPost(int size)
        {
            return context.Posts.OrderByDescending(b => b.PostedOn)
                                .Take(size)
                                .ToList();
        }

        /// <summary>
        /// Function Get Most Viewed Post
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public IList<Posts> GetMostViewedPost(int size)
        {
            var posts = context.Posts.Where(p => p.Published).ToList();

            posts.Sort((p1, p2) => p2.ViewCount.CompareTo(p1.ViewCount));

            return posts.Take(size).ToList();
        }

        public Posts GetPosts(int id)
        {
            return context.Posts.FirstOrDefault(p => p.PostId == id);
        }

        /// <summary>
        /// Function Get Posts By Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IList<Posts> GetPostsByCategory(string category)
        {
            return context.Posts.Where(p => p.Categories.Name == category).ToList();
        }

        /// <summary>
        /// Function Get Posts By Month
        /// </summary>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        public IList<Posts> GetPostsByMonth(DateTime monthYear)
        {
            return context.Posts.Where(b => b.PostedOn.Month == monthYear.Month 
                                        && b.PostedOn.Year == monthYear.Year)
                                .ToList();

        }

        /// <summary>
        /// Function Get Publised Posts
        /// </summary>
        /// <returns></returns>
        public IList<Posts> GetPublisedPosts()
        {
            return context.Posts.Where(p => p.Published == true).ToList();
        }

        /// <summary>
        /// Function Get Unpublised Posts
        /// </summary>
        /// <returns></returns>
        public IList<Posts> GetUnpublisedPosts()
        {
            return context.Posts.Where(p => p.Published == false).ToList();
        }
    }
}
