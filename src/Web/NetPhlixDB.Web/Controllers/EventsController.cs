using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsService _eventsService;

        public EventsController(IEventsService eventsService)
        {
            this._eventsService = eventsService;
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            var events = await this._eventsService.GetAll();
            return this.View(events);
        }

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            var ev = await this._eventsService.GetById(id);

            if (ev == null)
            {
                return this.NotFound();
            }

            return this.View(ev);
        }
    }
}