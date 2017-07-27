using MyProjectWebApiDotNET.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProjectWebApiDotNET.Domain
{
    public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected IList<T> _inMemoryList;
             
        public InMemoryRepository(IList<T> memoryList)
        {
            _inMemoryList = memoryList;
        }

        public T Add(T entity)
        {
            _inMemoryList.Add(entity);
            return _inMemoryList.FirstOrDefault(o => o.Id == entity.Id);
        }

        public void Delete(int id)
        {
            _inMemoryList.Remove(_inMemoryList.FirstOrDefault(o => o.Id == id));
        }

        public T Edit(T entity)
        {
            var index = _inMemoryList.IndexOf(_inMemoryList.FirstOrDefault(o => o.Id == entity.Id));
            _inMemoryList[index] = entity;
            return _inMemoryList.FirstOrDefault(o => o.Id == entity.Id);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _inMemoryList.AsQueryable().Where(predicate);
        }

        public IEnumerable<T> FindAll()
        {
            return _inMemoryList;
        }
    }
}