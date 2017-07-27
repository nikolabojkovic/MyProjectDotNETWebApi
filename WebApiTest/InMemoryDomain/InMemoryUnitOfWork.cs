using MyProjectWebApiDotNET.Interfaces;
using MyProjectWebApiDotNET.Models;

namespace MyProjectWebApiDotNET.Domain
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private InMemoryRepository<Hero> _heroes;

        public InMemoryUnitOfWork()
        {
            Commited = false;
        }

        public IRepository<Hero> Heroes
        {
            get
            {
                if (_heroes == null)
                    return _heroes = new InMemoryRepository<Hero>(HeroInMemoryData.heroes);

                return _heroes;
            }
        }

        public bool Commited { get; set; }

        public void Commit()
        {
            Commited = true;
        }
    }
}