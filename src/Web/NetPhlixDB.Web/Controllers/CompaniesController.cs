using System.Threading.Tasks;
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

        public async Task<IActionResult> Details(string id)
        {
            var companyDetails = await this._companiesService.GetCompanyDetails(id);
            
            if (companyDetails == null)
            {
                return this.NotFound();
            }

            return View(companyDetails);
        }

        public async Task<IActionResult> All()
        {
            var allCompanies = await this._companiesService.GetAll();
            
            return this.View(allCompanies);
        }
    }
}