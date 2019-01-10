using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Admin.Companies;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompaniesController : Controller
    {
        private readonly NetPhlixDbContext _context;
        private readonly IMapper _mapper;

        public CompaniesController(NetPhlixDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var companies = await _context.Companies.OrderByDescending(x => x.CreatedOn).ToListAsync();
            var companyViewModels =
                this._mapper.Map<IEnumerable<Company>, IEnumerable<IndexCompanyViewModel>>(companies);
            return View(companyViewModels);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            var companyViewModel = this._mapper.Map<Company, EditDeleteDetailsCompanyViewModel>(company);

            return View(companyViewModel);
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
                var company = this._mapper.Map<CreateCompanyViewModel, Company>(viewModel);

                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            var editDeleteViewModel = this._mapper.Map<Company, EditDeleteDetailsCompanyViewModel>(company);

            return View(editDeleteViewModel);
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
                var company = this._mapper.Map<EditDeleteDetailsCompanyViewModel, Company>(viewModel);

                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
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

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            var companyViewModel = this._mapper.Map<Company, EditDeleteDetailsCompanyViewModel>(company);

            return View(companyViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var company = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(string id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
