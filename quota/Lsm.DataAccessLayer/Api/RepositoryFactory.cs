namespace DoE.Lsm.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using DoE.Lsm.Logger;

    public class RepositoryFactory<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly DbContext _DbContext;
        protected readonly ILogger _logger;

        /// <summary>
        ///     This will default to [0] to prevent unwanted locking of entities.
        /// </summary>
        protected readonly bool requiresLock = false;

        public RepositoryFactory(DbContext context, ILogger logger)
        {
            this._DbContext = context;
            this._logger    = logger;
        }

        public virtual TEntity Single(int id)
        {
            return _DbContext.Set<TEntity>().Find(id);
        }

        public async virtual Task<TEntity> SingleAsync(int id)
        {
            return await _DbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual void Create(TEntity entity)
        {
            _DbContext.Set<TEntity>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _DbContext.Set<TEntity>().AddRange(entities);
        }

        public virtual IEnumerable<TEntity> ManyAsync(Expression<Func<TEntity , bool>> predicate)
        {
            return _DbContext.Set<TEntity>().Where(predicate);
        }

        public virtual void Remove(TEntity entity)
        {
            _DbContext.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _DbContext.Set<TEntity>().RemoveRange(entities);
        }

        public IEnumerable<TEntity> Many(Expression<Func<TEntity, bool>> predicate)
        {
            return _DbContext.Set<TEntity>().Where(predicate);
        }
    }
}
