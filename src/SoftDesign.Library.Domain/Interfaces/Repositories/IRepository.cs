using SoftDesign.Library.Domain.Entities.Core;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace SoftDesign.Library.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        #region === CREATE ===

        Task Create(TEntity obj);
        Task CreateList(List<TEntity> list);

        #endregion

        #region === READ ===

        Task<int> Count();
        Task<int> Count(Expression<Func<TEntity, bool>> func);
        Task<bool> Exists(Expression<Func<TEntity, bool>> func);
        Task<TEntity> Read(long entityId);
        Task<TEntity> ReadAsNoTracking(long entityId);
        Task<TEntity> ReadWithParameters(Expression<Func<TEntity, bool>> func);
        Task<TEntity> ReadWithParametersIncluding(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> ReadWithParametersAsNoTracking(Expression<Func<TEntity, bool>> func);
        Task<TEntity> ReadWithParametersAsNoTrackingIncluding(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes);
        Task<IList<TEntity>> ReadAll();
        Task<IList<TEntity>> ReadAllAsNoTracking();
        Task<IList<TEntity>> ReadAllWithParameters(Expression<Func<TEntity, bool>> func);
        Task<IList<TEntity>> ReadAllWithParametersAsNoTracking(Expression<Func<TEntity, bool>> func);
        Task<IList<TEntity>> ReadAllIncluding(params Expression<Func<TEntity, object>>[] includes);
        Task<IList<TEntity>> ReadAllAsNoTrackingIncluding(params Expression<Func<TEntity, object>>[] includes);
        Task<IList<TEntity>> ReadAllWithParametersIncluding(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes);
        Task<IList<TEntity>> ReadAllWithParametersAsNoTrackingIncluding(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes);

        #endregion

        #region === UPDATE ===

        Task Update(TEntity obj);

        #endregion

        #region === DELETE ===
    
        Task Delete(TEntity obj);

        #endregion

        Task SaveChanges();
    }
}
