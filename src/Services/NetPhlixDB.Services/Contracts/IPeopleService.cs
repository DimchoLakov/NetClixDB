using System.Collections.Generic;
using System.Threading.Tasks;
using NetPhlixDb.Data.ViewModels.People;

namespace NetPhlixDB.Services.Contracts
{
    public interface IPeopleService
    {
        Task<IEnumerable<PersonViewModel>> GetAll();

        Task<PersonViewModel> GetById(string id);
    }
}
