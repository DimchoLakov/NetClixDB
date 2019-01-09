using System.Collections.Generic;
using System.Threading.Tasks;
using NetPhlixDb.Data.ViewModels.Companies;

namespace NetPhlixDB.Services.Contracts
{
    public interface ICompaniesService
    {
        Task<CompanyViewModel> GetCompanyDetails(string id);

        Task<IEnumerable<CompanyShortViewModel>> GetAll();
    }
}
