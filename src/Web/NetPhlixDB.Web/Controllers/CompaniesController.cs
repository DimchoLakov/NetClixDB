using Microsoft.AspNetCore.Mvc;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompaniesService _companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            this._companiesService = companiesService;
        }

        public IActionResult Details(string id)
        {
            var companyDetails = this._companiesService.GetCompanyDetails(id);

            return View(companyDetails);
        }

        public IActionResult All()
        {
            var allCompanies = this._companiesService.GetAll();
            
            return this.View(allCompanies);
        }
    }
}