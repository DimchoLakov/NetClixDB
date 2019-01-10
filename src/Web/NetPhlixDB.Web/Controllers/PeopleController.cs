using System.Threading.Tasks;
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
        public async Task<IActionResult> Details(string id)
        {
            var personViewModel = await this._peopleService.GetById(id);

            if (personViewModel == null)
            {
                return this.NotFound();
            }

            return View(personViewModel);
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            var people = await this._peopleService.GetAll();

            return this.View(people);
        }
    }
}