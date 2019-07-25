using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Admin.Genres;
using NetPhlixDB.Data;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Services
{
    public class GenresService : IGenresService
    {
        private readonly NetPhlixDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenresService(NetPhlixDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<IndexGenreViewModel>> GetAllAsync()
        {
            var allGenres = await this._dbContext.Genres.ToListAsync();
            var genres = this._mapper.Map<IEnumerable<IndexGenreViewModel>>(allGenres);
            return genres;
        }

        public async Task<EditDeleteDetailsGenreViewModel> GetByIdAsync(string id)
        {
            var genre = await this._dbContext.Genres.FindAsync(id);
            var genreViewModel = this._mapper.Map<EditDeleteDetailsGenreViewModel>(genre);
            return genreViewModel;
        }

        public Task<int?> CreateAsync(CreateGenreViewModel genreViewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<int?> EditAsync(EditDeleteDetailsGenreViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<int?> DeleteAsync(EditDeleteDetailsGenreViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> GenreExistsAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
