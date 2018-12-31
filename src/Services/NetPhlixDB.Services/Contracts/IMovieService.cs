using NetPhlixDb.Data.ViewModels;

namespace NetPhlixDB.Services.Contracts
{
    public interface IMovieService
    {
        void Add(MovieViewModel viewModel);
    }
}
