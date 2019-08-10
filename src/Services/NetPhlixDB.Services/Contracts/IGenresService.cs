using System.Collections.Generic;
using System.Threading.Tasks;
using NetPhlixDb.Data.ViewModels.Admin.Genres;

namespace NetPhlixDB.Services.Contracts
{
    public interface IGenresService
    {
        Task<IEnumerable<IndexGenreViewModel>> GetAllAsync();

        Task<EditDeleteDetailsGenreViewModel> GetByIdAsync(string id);

        Task<int?> CreateAsync(CreateGenreViewModel genreViewModel);

        Task<int?> EditAsync(EditDeleteDetailsGenreViewModel viewModel);

        Task<int?> DeleteAsync(EditDeleteDetailsGenreViewModel viewModel);

        Task<bool> GenreExistsAsync(string id);
    }
}
