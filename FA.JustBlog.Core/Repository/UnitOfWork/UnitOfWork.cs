using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Repository.ImplementRepo;
using FA.JustBlog.Core.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext context;
        private ICategoryRepository categoryRepository;
        private IPostRepository postRepository;
        private ITagRepository tagRepository;
        private ICommentsRepository commentsRepository;
        public UnitOfWork(JustBlogContext context = null)
        {
            this.context = context ?? new JustBlogContext();
        }

        public ICategoryRepository Category => categoryRepository ?? new CategoriesRepository(context);

        public IPostRepository Post => postRepository ?? new PostRepository(context);

        public ITagRepository Tag => tagRepository ?? new TagRepository(context);
        public ICommentsRepository Comments => commentsRepository ?? new CommentsRepository(context);   
        public void SaveChange()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();

                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
