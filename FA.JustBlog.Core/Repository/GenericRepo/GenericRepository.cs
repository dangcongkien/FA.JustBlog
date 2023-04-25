using FA.JustBlog.Core.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository.GenericRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly JustBlogContext context;
        protected DbSet<T> dbSet;

        public GenericRepository(JustBlogContext context = null)
        {
            this.context = context ?? new JustBlogContext();
            dbSet = context.Set<T>();
        }

        /// <summary>
        /// Function to Add new entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
            
        }

        /// <summary>
        /// Function to remove a entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        /// <summary>
        /// Function to remove a entity by id
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(int id)
        {
            T entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        /// <summary>
        /// Function to find a entity
        /// </summary>
        /// <param name="entity"></param>
        public T Find(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Function to get all element
        /// </summary>
        /// <param name="entity"></param>
        public IList<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetEntityById(int id)
        {
            return dbSet.Find(id);
        }


        /// <summary>
        /// Function to update a entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
