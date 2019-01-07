using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public IEnumerable<PersonViewModel> GetAll()
        {
            var people = this._dbContext.People.ToList();
            var personViewModels = this._mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(people);

            return personViewModels;
        }

        public PersonViewModel GetById(string id)
        {
            var person = this._dbContext.People.FirstOrDefault(x => x.Id == id);
            var personViewModel = this._mapper.Map<Person, PersonViewModel>(person);
            var personMovies = this._dbContext.MoviePeople.Where(x => x.PersonId == id).Select(x => x.Movie);
            var personMovieViewModels = this._mapper.Map<IEnumerable<Movie>, IEnumerable<PersonMovieViewModel>>(personMovies);

            personViewModel.PersonMovieViewModels = personMovieViewModels.ToList();
            return personViewModel;
        }
    }
}
