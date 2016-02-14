using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private StoreEntities _dataContext;
        private readonly IDbSet<T> _dbSet;

        protected IDbFactory DbFactory { get; private set; }

        public StoreEntities DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        public virtual void Add(T entity) => _dbSet.Add(entity);

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity) => _dbSet.Remove(entity);

        public virtual void Delete(Expression<Func<T, Boolean>> where)
        {
            IEnumerable<T> objects = _dbSet.Where(where).AsEnumerable();
            foreach (T obj in objects)
            {
                _dbSet.Remove(obj);
            }
        }

        public virtual T GetById(int id) => _dbSet.Find(id);

        public virtual IEnumerable<T> GetAll() => _dbSet.ToList();

        public virtual IEnumerable<T> GetMany(Expression<Func<T, Boolean>> where) => _dbSet.Where(where).ToList();

        public T Get(Expression<Func<T, Boolean>> where) => _dbSet.Where(where).FirstOrDefault();
    }
}
