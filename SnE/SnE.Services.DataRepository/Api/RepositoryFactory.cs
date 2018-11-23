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
        {this._DbContext = context; this._logger    = logger;}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Single(int id)
        {
            return _DbContext.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async virtual Task<TEntity> SingleAsync(int id)
        {
            return await _DbContext.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Push(TEntity entity)
        {
            _DbContext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _DbContext.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> ManyAsync(Expression<Func<TEntity , bool>> predicate)
        {
            return _DbContext.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(TEntity entity)
        {
            _DbContext.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _DbContext.Set<TEntity>().RemoveRange(entities);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Many(Expression<Func<TEntity, bool>> predicate)
        {
            return _DbContext.Set<TEntity>().Where(predicate);
        }
    }
}
