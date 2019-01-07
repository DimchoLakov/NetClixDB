using System.Collections.Generic;
using NetPhlixDb.Data.ViewModels.Companies;

namespace NetPhlixDB.Services.Contracts
{
    public interface ICompaniesService
    {
        CompanyViewModel GetCompanyDetails(string id);

        IEnumerable<CompanyShortViewModel> GetAll();
    }
}
