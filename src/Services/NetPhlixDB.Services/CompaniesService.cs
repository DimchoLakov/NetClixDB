using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<CompanyViewModel> GetCompanyDetails(string id)
        {
            var company = await this._dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
            var companyViewModel = this._mapper.Map<Company, CompanyViewModel>(company);
            var companyMovies = await this._dbContext.MovieCompanies.Where(x => x.CompanyId == id).Select(x => x.Movie).ToListAsync();
            var companyMoviesViewModels = this._mapper.Map<IEnumerable<Movie>, IEnumerable<CompanyMovieViewModel>>(companyMovies);

            companyViewModel.CompanyMoviesViewModels = companyMoviesViewModels;

            return companyViewModel;
        }

        public async Task<IEnumerable<CompanyShortViewModel>> GetAll()
        {
            var companies = await this._dbContext.Companies.ToListAsync();
            var allCompanies = this._mapper.Map<IEnumerable<Company>, IEnumerable<CompanyShortViewModel>>(companies);
            return allCompanies;
        }
    }
}
