using FA.JustBlog.Core.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IPostRepository Post { get; }
        ITagRepository Tag { get; }
        ICommentsRepository Comments { get; }
        void SaveChange();
    }
}
