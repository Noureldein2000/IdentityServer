using IdentityServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IdentityServer.Repositories.Base
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Getwhere(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity GetById(TKey key);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        TEntity Delete(TKey key);
    }
}
