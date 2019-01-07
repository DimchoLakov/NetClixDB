using System.Collections.Generic;
using NetPhlixDb.Data.ViewModels.People;

namespace NetPhlixDB.Services.Contracts
{
    public interface IPeopleService
    {
        IEnumerable<PersonViewModel> GetAll();

        PersonViewModel GetById(string id);
    }
}
