using System.Collections.Generic;
using NetPhlixDb.Data.ViewModels.Events;

namespace NetPhlixDB.Services.Contracts
{
    public interface IEventsService
    {
        IEnumerable<EventViewModel> GetAll();

        EventViewModel GetById(string id);
    }
}
