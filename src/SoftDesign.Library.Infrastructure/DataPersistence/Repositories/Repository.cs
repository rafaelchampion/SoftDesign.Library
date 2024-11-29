using SoftDesign.Library.Domain.Entities.Core;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SoftDesign.Library.Infrastructure.DataPersistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            _dbSet.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            _dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
