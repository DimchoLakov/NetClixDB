using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetPhlixDB.Web.Controllers
{
    public class EventsController : Controller
    {
        [Authorize]
        public IActionResult All()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            return this.View();
        }
    }
}