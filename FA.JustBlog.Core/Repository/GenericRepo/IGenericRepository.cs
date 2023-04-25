using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository.GenericRepo
{
    public interface IGenericRepository<T> where T : class
    {
        T Find(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        IList<T> GetAll();
        T GetEntityById(int id);
    }
}
