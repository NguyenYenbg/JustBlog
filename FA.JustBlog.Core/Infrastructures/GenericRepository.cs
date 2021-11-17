using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Infrastructures
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly JustBlogContext context;
        private DbSet<TEntity> dbSet;
        public GenericRepository(JustBlogContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }


        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public void Delete(int key)
        {
            Delete(GetById(key));
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> condition)
        {
            return this.dbSet.Where(condition);
        }

        public IList<TEntity> GetAll()
        {
            return this.dbSet.ToList();
        }

        public TEntity GetById(int key)
        {
            return this.dbSet.Find(key);
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(int key)
        {
            Update(GetById(key));
        }
    }
}
