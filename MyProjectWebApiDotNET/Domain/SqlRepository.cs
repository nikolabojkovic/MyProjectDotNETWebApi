using MyProjectWebApiDotNET.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MyProjectWebApiDotNET.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbContext _dbContext;

        public SqlRepository(DbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<T> FindAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public T Add(T entity)
        {
            return _dbContext.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Set<T>().FirstOrDefault(o => o.Id == id);
            _dbContext.Set<T>().Remove(entity);
        }

        public T Edit(T entity)
        {
            _dbContext.Set<T>().AddOrUpdate(entity);
            return _dbContext.Set<T>().SingleOrDefault(o => o.Id == entity.Id);
        }
    }
}