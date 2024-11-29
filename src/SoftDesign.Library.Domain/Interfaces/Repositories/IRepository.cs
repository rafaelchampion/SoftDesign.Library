using SoftDesign.Library.Domain.Entities.Core;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace SoftDesign.Library.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
    }
}
