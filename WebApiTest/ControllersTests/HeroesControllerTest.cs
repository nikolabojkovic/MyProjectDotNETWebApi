using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProjectWebApiDotNET.Controllers;
using MyProjectWebApiDotNET.Domain;
using System.Web.Http.Results;
using MyProjectWebApiDotNET.Models;
using MyProjectWebApiDotNET.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace WebApiTest
{
    [TestClass]
    public class HeroesControllerTest
    {
        protected HeroesController _controller;
        protected IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void TestInitialize()
        {
            _unitOfWork = new InMemoryUnitOfWork();
            _controller = new HeroesController(_unitOfWork);
        }

        [TestMethod]
        public void GetAllHeroes_ShouldReturnAllHeroes()
        {
            JsonResult<IEnumerable<Hero>> result = _controller.Get() as JsonResult<IEnumerable<Hero>>;
            Hero[] heroesResult = result.Content.ToArray();
            Assert.AreEqual(heroesResult[0].Id, 1);
            Assert.AreEqual(heroesResult[0].Name, "Bart Simpson");
            Assert.AreEqual(heroesResult[1].Id, 2);
            Assert.AreEqual(heroesResult[1].Name, "Lisa Simpson");
        }

        [TestMethod]
        public void GetHeroById_ShouldReturnHeroForSelectedId()
        {
            JsonResult<Hero> result = _controller.Get(2) as JsonResult<Hero>;
            Assert.AreEqual(result.Content.Id, 2);
            Assert.AreEqual(result.Content.Name, "Lisa Simpson");
        }

        [TestMethod]
        public void AddHero_ShouldReturnHeroThatIsAdded()
        {
            JsonResult<Hero> result = _controller.Post(new Hero { Id = 7, Name = "Barny" }) as JsonResult<Hero>;
            Assert.AreEqual(result.Content.Id, 7);
            Assert.AreEqual(result.Content.Name, "Barny");
            Assert.AreEqual(((InMemoryUnitOfWork)_unitOfWork).Commited, true);
        }

        [TestMethod]
        public void UpdateHero_ShouldReturnUpdatedHero()
        {
            Hero heroToUpdate = new Hero { Id = 2, Name = "Bart Simpson updated" };
            JsonResult<Hero> result = _controller.Put(heroToUpdate) as JsonResult<Hero>;
            Assert.AreEqual(result.Content.Id, 2);
            Assert.AreEqual(result.Content.Name, "Bart Simpson updated");
            Assert.AreEqual(((InMemoryUnitOfWork)_unitOfWork).Commited, true);
        }

        [TestMethod]
        public void DeleteHero_ShouldReturnNullIfHeroIsSuccessfulyDeleted()
        {
            _controller.Delete(2);

            var result = _unitOfWork.Heroes.Find(o => o.Id == 2).SingleOrDefault() as Hero;
            Assert.AreEqual(result, null);
            Assert.AreEqual(((InMemoryUnitOfWork)_unitOfWork).Commited, true);
        }
    }
}
