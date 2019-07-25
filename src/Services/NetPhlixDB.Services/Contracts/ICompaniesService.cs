using System.Collections.Generic;
using System.Threading.Tasks;
using NetPhlixDb.Data.ViewModels.Admin.Companies;
using NetPhlixDb.Data.ViewModels.Companies;

namespace NetPhlixDB.Services.Contracts
{
    public interface ICompaniesService
    {
        Task<bool> CompanyExists(string id);

        Task<int?> Delete(string id);

        Task<int?> Update(EditDeleteDetailsCompanyViewModel viewModel);

        Task<int> Create(CreateCompanyViewModel viewModel);

        Task<EditDeleteDetailsCompanyViewModel> GetByIdAdmin(string id);

        Task<CompanyViewModel> GetById(string id);

        Task<IEnumerable<CompanyShortViewModel>> GetAll();
    }
}
