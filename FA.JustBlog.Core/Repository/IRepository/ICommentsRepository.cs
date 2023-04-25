using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository.IRepository
{
    public interface ICommentsRepository : IGenericRepository<Comments>
    {
        void AddComment(int postId, string commentName, string commentEmail, string commentTitle,
        string commentBody);
        IList<Comments> GetCommentsForPost(int postId);
        IList<Comments> GetCommentsForPost(Posts post);
    }
}
