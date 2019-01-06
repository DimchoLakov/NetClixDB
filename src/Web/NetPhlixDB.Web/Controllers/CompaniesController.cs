using Microsoft.AspNetCore.Mvc;

namespace NetPhlixDB.Web.Controllers
{
    public class CompaniesController : Controller
    {
        public IActionResult Details(string id)
        {
            return View();
        }
    }
}