using MyProjectWebApiDotNET.Domain;
using MyProjectWebApiDotNET.Interfaces;
using MyProjectWebApiDotNET.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyProjectWebApiDotNET.Controllers
{
    [RoutePrefix("api/heroes")]
    public class HeroesController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public HeroesController()
        {
            _unitOfWork = new SqlUnitOfWork(new Context()); // this should be injected in contructor
        }

        public HeroesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get ()
        {
            if (_unitOfWork.Heroes.FindAll().Count() == 0)
                return NotFound();

            return Json(_unitOfWork.Heroes.FindAll());
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(_unitOfWork.Heroes.Find(x => x.Id == id).SingleOrDefault());
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetHeroesByName(string name)
        {
            return Json(_unitOfWork.Heroes.Find(o => o.Name.Contains(name)));
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Hero hero)
        {
            var newHero = _unitOfWork.Heroes.Add(hero);
            _unitOfWork.Commit();
            return Json(newHero);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Put(Hero hero)
        {
            var updatedHero = _unitOfWork.Heroes.Edit(hero);
            _unitOfWork.Commit();
            return Json(updatedHero);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _unitOfWork.Heroes.Delete(id);
            _unitOfWork.Commit();
            return Ok();
        }
    }
}