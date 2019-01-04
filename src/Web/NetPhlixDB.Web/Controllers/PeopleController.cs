using Microsoft.AspNetCore.Mvc;

namespace NetPhlixDB.Web.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Details(string id)
        {
            return View();
        }
    }
}