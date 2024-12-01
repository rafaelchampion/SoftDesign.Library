using SoftDesign.Library.Domain.Entities.Core;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SoftDesign.Library.Infrastructure.DataPersistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly DbContext _context;
        public readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        #region === CREATE ===

        public async Task Create(TEntity obj)
        {
            _dbSet.Add(obj);
            await SaveChanges();
        }

        public async Task CreateList(List<TEntity> list)
        {
            _dbSet.AddRange(list);
            await SaveChanges();
        }
        
        #endregion

        public async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> func)
        {
            return await _dbSet.CountAsync();
        }

        public async Task<bool> Exists(Expression<Func<TEntity, bool>> func)
        {
            return await _dbSet.AnyAsync(func);
        }

        public async Task<TEntity> Read(long entityId)
        {
            return await _dbSet.FindAsync(entityId);
        }
        
        public async Task<TEntity> ReadAsNoTracking(long entityId)
        {
            var entity = await _dbSet.FindAsync(entityId);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<TEntity> ReadWithParameters(Expression<Func<TEntity, bool>> func)
        {
            return await _dbSet.Where(func).FirstOrDefaultAsync();
        }

        public async Task<TEntity> ReadWithParametersIncluding(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.Where(func);
            return await includes.Aggregate(query, (current, include) => current.Include(include)).FirstOrDefaultAsync();
        }

        public async Task<TEntity> ReadWithParametersAsNoTracking(Expression<Func<TEntity, bool>> func)
        {
            return await _dbSet.Where(func).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<TEntity> ReadWithParametersAsNoTrackingIncluding(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.Where(func);
            return await includes.Aggregate(query, (current, include) => current.Include(include)).AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IList<TEntity>> ReadAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IList<TEntity>> ReadAllAsNoTracking()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IList<TEntity>> ReadAllWithParameters(Expression<Func<TEntity, bool>> func)
        {
            return await _dbSet.Where(func).ToListAsync();
        }

        public async Task<IList<TEntity>> ReadAllWithParametersAsNoTracking(Expression<Func<TEntity, bool>> func)
        {
            return await _dbSet.Where(func).AsNoTracking().ToListAsync();
        }

        public async Task<IList<TEntity>> ReadAllIncluding(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            return await includes.Aggregate(query, (current, include) => current.Include(include)).ToListAsync();
        }

        public async Task<IList<TEntity>> ReadAllAsNoTrackingIncluding(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            return await includes.Aggregate(query, (current, include) => current.Include(include)).AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<TEntity>> ReadAllWithParametersIncluding(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.Where(func);
            return await includes.Aggregate(query, (current, include) => current.Include(include)).ToListAsync();
        }

        public async Task<IList<TEntity>> ReadAllWithParametersAsNoTrackingIncluding(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.Where(func);
            return await includes.Aggregate(query, (current, include) => current.Include(include)).AsNoTracking()
                .ToListAsync();
        }

        public async Task Update(TEntity obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await SaveChanges();
        }

        public async Task Delete(TEntity obj)
        {
            _dbSet.Remove(obj);
            await SaveChanges();
        }
        
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
