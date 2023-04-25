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
    public class CommentsRepository : GenericRepository<Comments>, ICommentsRepository
    {
        public CommentsRepository(JustBlogContext context = null) : base(context)
        {
        }

        /// <summary>
        /// Function add new a Comments
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentName"></param>
        /// <param name="commentEmail"></param>
        /// <param name="commentTitle"></param>
        /// <param name="commentBody"></param>
        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            Comments comments = new Comments
            {
                PostId = postId,
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody
            };
            context.Add(comments);
            context.SaveChanges();
        }

        /// <summary>
        /// Function Get Comments For Post by id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IList<Comments> GetCommentsForPost(int postId)
        {
            return context.Comments.Where(c => c.PostId == postId).ToList();
        }

        /// <summary>
        /// Function Get Comments For Posts
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public IList<Comments> GetCommentsForPost(Posts post)
        {
            return context.Comments.Where(c => c.PostId == post.PostId).ToList();
        }

    }
}
