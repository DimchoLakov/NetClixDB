using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.WebApi.DTOs;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;

namespace NetPhlixDb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly NetPhlixDbContext _dbContext;

        public MoviesController(NetPhlixDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAllAsync()
        {
            var movies = await this._dbContext.Movies.ToListAsync();

            var movieDtos = movies.Select(x => new MovieDto()
            {
                Title = x.Title,
                DateReleased = x.DateReleased.ToString("dd/MMM/yyyy"),
                Language = x.Language.ToString(),
                Poster = x.Poster,
                Trailer = x.Trailer,
                Storyline = x.Storyline,
                Persons = x.MoviePeople.Select(mp => new MoviePersonDto()
                {
                    PersonRole = mp.Person.PersonRole.ToString(),
                    BirthDate = mp.Person.BirthDate.ToString("dd/MMM/yyyy"),
                    BirthPlace = mp.Person.BirthPlace,
                    Name = mp.Person.FirstName + " " + mp.Person.LastName
                }),
                Companies = x.MovieCompanies.Select(mc => new MovieCompanyDto()
                {
                    Name = mc.Company.Name,
                    CreatedOn = mc.Company.CreatedOn.ToString("dd/MMM/yyyy"),
                    Details = mc.Company.Details,
                    Logo = mc.Company.Logo,
                    OriginCountry = mc.Company.OriginCountry
                })
            });

            return this.Ok(movieDtos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> Get(string id)
        {
            var movie = await this._dbContext.Movies.FindAsync(id);

            var movieDto = new MovieDto()
            {
                Title = movie.Title,
                DateReleased = movie.DateReleased.ToString("dd/MMM/yyyy"),
                Language = movie.Language.ToString(),
                Poster = movie.Poster,
                Trailer = movie.Trailer,
                Storyline = movie.Storyline,
                Persons = movie.MoviePeople.Select(mp => new MoviePersonDto()
                {
                    PersonRole = mp.Person.PersonRole.ToString(),
                    BirthDate = mp.Person.BirthDate.ToString("dd/MMM/yyyy"),
                    BirthPlace = mp.Person.BirthPlace,
                    Name = mp.Person.FirstName + " " + mp.Person.LastName
                }),
                Companies = movie.MovieCompanies.Select(mc => new MovieCompanyDto()
                {
                    Name = mc.Company.Name,
                    CreatedOn = mc.Company.CreatedOn.ToString("dd/MMM/yyyy"),
                    Details = mc.Company.Details,
                    Logo = mc.Company.Logo,
                    OriginCountry = mc.Company.OriginCountry
                })
            };

            return movieDto;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
