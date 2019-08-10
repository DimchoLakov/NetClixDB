using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Admin.Companies;
using NetPhlixDb.Data.ViewModels.Companies;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly NetPhlixDbContext _dbContext;
        private readonly IMapper _mapper;

        public CompaniesService(NetPhlixDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<int?> Delete(string id)
        {
            if (!await this.CompanyExists(id))
            {
                return null;
            }

            var company = await this._dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);

            this._dbContext.Companies.Remove(company);
            return await this._dbContext.SaveChangesAsync();
        }

        public async Task<bool> CompanyExists(string id)
        {
            return await this._dbContext.Companies.AnyAsync(e => e.Id == id);
        }

        public async Task<int?> Update(EditDeleteDetailsCompanyViewModel viewModel)
        {
            if (!await this.CompanyExists(viewModel.Id))
            {
                return null;
            }

            var company = this._mapper.Map<EditDeleteDetailsCompanyViewModel, Company>(viewModel);

            this._dbContext.Update(company);
            return await this._dbContext.SaveChangesAsync();
        }

        public async Task<EditDeleteDetailsCompanyViewModel> GetByIdAdmin(string id)
        {
            var company = await this._dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
            var editDeleteDetailsViewModel = this._mapper.Map<Company, EditDeleteDetailsCompanyViewModel>(company);

            return editDeleteDetailsViewModel;
        }

        public async Task<CompanyViewModel> GetById(string id)
        {
            var company = await this._dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (company == null)
            {
                return null;
            }
            var companyViewModel = this._mapper.Map<Company, CompanyViewModel>(company);
            var companyMovies = await this._dbContext.MovieCompanies.Where(x => x.CompanyId == id).Select(x => x.Movie).ToListAsync();
            var companyMoviesViewModels = this._mapper.Map<IEnumerable<Movie>, IEnumerable<CompanyMovieViewModel>>(companyMovies);

            companyViewModel.CompanyMoviesViewModels = companyMoviesViewModels;

            return companyViewModel;
        }

        public async Task<IEnumerable<CompanyShortViewModel>> GetAll()
        {
            var companies = await this._dbContext.Companies.OrderBy(x => x.Name).ToListAsync();
            var allCompanies = this._mapper.Map<IEnumerable<Company>, IEnumerable<CompanyShortViewModel>>(companies);
            return allCompanies;
        }

        public async Task<int> Create(CreateCompanyViewModel viewModel)
        {
            var company = this._mapper.Map<CreateCompanyViewModel, Company>(viewModel);

            await this._dbContext.AddAsync(company);

            return await this._dbContext.SaveChangesAsync();
        }
    }
}
