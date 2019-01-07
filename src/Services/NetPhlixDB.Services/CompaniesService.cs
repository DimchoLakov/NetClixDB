using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public CompanyViewModel GetCompanyDetails(string id)
        {
            var company = this._dbContext.Companies.FirstOrDefault(x => x.Id == id);
            var companyViewModel = this._mapper.Map<Company, CompanyViewModel>(company);
            var companyMovies = this._dbContext.MovieCompanies.Where(x => x.CompanyId == id).Select(x => x.Movie).ToList();
            var companyMoviesViewModels = this._mapper.Map<IEnumerable<Movie>, IEnumerable<CompanyMovieViewModel>>(companyMovies);

            companyViewModel.CompanyMoviesViewModels = companyMoviesViewModels;

            return companyViewModel;
        }

        public IEnumerable<CompanyShortViewModel> GetAll()
        {
            var companies = this._dbContext.Companies.ToList();
            var allCompanies = this._mapper.Map<IEnumerable<Company>, IEnumerable<CompanyShortViewModel>>(companies);
            return allCompanies;
        }
    }
}
