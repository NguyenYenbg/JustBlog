using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Infrastructures
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int key);
        IEnumerable<TEntity> Find(Func<TEntity, bool> condition);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Update(int key);
        void Delete(TEntity entity);
        void Delete(int key);

        IList<TEntity> GetAll();

    }
}
