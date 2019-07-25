using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Admin.Companies;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompaniesController : Controller
    {
        private readonly NetPhlixDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICompaniesService _companiesService;

        public CompaniesController(NetPhlixDbContext context, IMapper mapper, ICompaniesService companiesService)
        {
            this._context = context;
            this._mapper = mapper;
            this._companiesService = companiesService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var companies = await this._companiesService.GetAll();
            
            return View(companies.OrderByDescending(x => x.CreatedOn));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            var company = await this._companiesService.GetByIdAdmin(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => View());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await this._companiesService.Create(viewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            var company = await this._companiesService.GetByIdAdmin(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditDeleteDetailsCompanyViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await this._companiesService.Update(viewModel);

                if (result == null)
                {
                    return this.NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyViewModel = await this._companiesService.GetByIdAdmin(id);

            if (companyViewModel == null)
            {
                return this.NotFound();
            }

            return View(companyViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var result = await this._companiesService.Delete(id);
            if (result == null)
            {
                return this.NotFound();
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
