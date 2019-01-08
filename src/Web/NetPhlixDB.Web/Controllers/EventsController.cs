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
        public IActionResult All()
        {
            var events = this._eventsService.GetAll();
            return this.View(events);
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var ev = this._eventsService.GetById(id);

            return this.View(ev);
        }
    }
}