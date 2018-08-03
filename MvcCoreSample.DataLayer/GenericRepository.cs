using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MvcCoreSample.DomainClasses;

namespace MvcCoreSample.DataLayer
{
    public class GenericRepository<TEntity> where TEntity : class, IEntity
    {
        internal DbContext _dbContext;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> All()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> result = _dbSet.AsNoTracking()
                .Where(predicate)
                .ToList();
            return result;
        }

        public TEntity FindByKey(int id)
        {
            return _dbSet.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }
    }
}