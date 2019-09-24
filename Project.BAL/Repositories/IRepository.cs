using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetBy(Func<TEntity, bool> predicate);
        TEntity Get(object id);
        bool Add(TEntity entity);
        bool AddRange(IEnumerable<TEntity> entity);
        bool Edit(TEntity entity);
        bool Remove(TEntity entity);

    }
}
