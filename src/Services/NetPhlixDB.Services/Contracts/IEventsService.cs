using System.Collections.Generic;
using System.Threading.Tasks;
using NetPhlixDb.Data.ViewModels.Events;

namespace NetPhlixDB.Services.Contracts
{
    public interface IEventsService
    {
        Task<IEnumerable<EventViewModel>> GetAll();

        Task<EventViewModel> GetById(string id);
    }
}
