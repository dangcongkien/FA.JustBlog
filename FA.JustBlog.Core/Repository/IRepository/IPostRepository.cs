using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository.IRepository
{
    public interface IPostRepository : IGenericRepository<Posts>
    {
        Posts FindPost(int year, int month, string urlSlug);
        Posts GetPosts(int id);
        IList<Posts> GetPublisedPosts();
        IList<Posts> GetUnpublisedPosts();
        IList<Posts> GetLatestPost(int size);
        IList<Posts> GetPostsByMonth(DateTime monthYear);
        int CountPostsForCategory(string category);
        IList<Posts> GetPostsByCategory(string category);
        IList<Posts> GetMostViewedPost(int size);
        IList<Posts> GetHighestPosts(int size);
    }
}
