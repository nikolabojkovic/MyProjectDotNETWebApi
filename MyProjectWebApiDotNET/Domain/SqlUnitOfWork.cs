using MyProjectWebApiDotNET.Interfaces;
using MyProjectWebApiDotNET.Models;
using System.Data.Entity;
using MyProjectWebApiDotNET.Repositories;

namespace MyProjectWebApiDotNET.Domain
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        private SqlRepository<Hero> _heroes;

        public SqlUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Hero> Heroes
        {
            get
            {
                if (_heroes == null)
                    return _heroes = new SqlRepository<Hero>(_dbContext);

                return _heroes;
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}