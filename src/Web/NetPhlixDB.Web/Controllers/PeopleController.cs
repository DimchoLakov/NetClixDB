using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            this._peopleService = peopleService;
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var personViewModel = this._peopleService.GetById(id);

            return View(personViewModel);
        }

        [Authorize]
        public IActionResult All()
        {
            var people = this._peopleService.GetAll();

            return this.View(people);
        }
    }
}