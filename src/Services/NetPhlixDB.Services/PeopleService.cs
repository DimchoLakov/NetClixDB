using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.People;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly NetPhlixDbContext _dbContext;
        private readonly IMapper _mapper;

        public PeopleService(NetPhlixDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<PersonViewModel>> GetAll()
        {
            var people = await this._dbContext.People.ToListAsync();
            var personViewModels = this._mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(people);

            return personViewModels;
        }

        public async Task<PersonViewModel> GetById(string id)
        {
            var person = await this._dbContext.People.FirstOrDefaultAsync(x => x.Id == id);
            if (person == null)
            {
                return null;
            }
            var personViewModel = this._mapper.Map<Person, PersonViewModel>(person);

            var personMovies = await this._dbContext.MoviePeople.Where(x => x.PersonId == id).Select(x => x.Movie).ToListAsync();
            var personMovieViewModels = this._mapper.Map<IEnumerable<Movie>, IEnumerable<PersonMovieViewModel>>(personMovies);

            personViewModel.PersonMovieViewModels = personMovieViewModels.ToList();
            return personViewModel;
        }
    }
}
