using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private RMSEntities dataContext;
        private readonly IDbSet<T> dbSet;

        protected IConnectionString connectionString
        {
            get;
            private set;
        }
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected RMSEntities DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        #endregion
        
        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
            this.dataContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            //dbSet.Attach(entity);
            //dataContext.Entry(entity).State = EntityState.Modified;
            dbSet.AddOrUpdate(entity);
            this.dataContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            dbSet.Attach(entity);
            dbSet.Remove(entity);
            this.dataContext.SaveChanges();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            
            var en = dbSet.Find(id);
            dataContext.Entry(en).State = EntityState.Detached;
            return en;
            
            
        }
       
        public virtual IEnumerable<T> GetAll()
        {
            var obj = dbSet.ToList();
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        #endregion

    }
}
