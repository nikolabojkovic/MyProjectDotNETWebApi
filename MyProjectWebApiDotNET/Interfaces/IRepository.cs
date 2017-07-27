using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyProjectWebApiDotNET.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Edit(T entity);
        void Delete(int id);
    }
}