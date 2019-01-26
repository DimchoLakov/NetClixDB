using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Admin.Movies;
using NetPhlixDb.Data.ViewModels.Admin.People;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Web.Extensions;

namespace NetPhlixDB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        private readonly NetPhlixDbContext _dbContext;
        private readonly IMapper _mapper;

        public MoviesController(NetPhlixDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var movies = await _dbContext.Movies.OrderByDescending(x => x.DateReleased).ToListAsync();
            var movieViewModels = this._mapper.Map<IEnumerable<Movie>, IEnumerable<IndexAdminMovieViewModel>>(movies);

            return View(movieViewModels);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => View());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var trailer = viewModel.Trailer.UrlToEmbedCode();
                if (trailer == null)
                {
                    return View(viewModel);
                }
                var movie = this._mapper.Map<CreateMovieViewModel, Movie>(viewModel);
                movie.Trailer = trailer;
                _dbContext.Add(movie);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            var movieViewModel = this._mapper.Map<Movie, EditMovieViewModel>(movie);

            return View(movieViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditMovieViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var movie = this._mapper.Map<EditMovieViewModel, Movie>(viewModel);
                movie.Trailer = movie.Trailer.UrlToEmbedCode();
                try
                {
                    _dbContext.Update(movie);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(string id)
        {
            return _dbContext.Movies.Any(e => e.Id == id);
        }

        private bool PersonExists(string id)
        {
            return _dbContext.People.Any(e => e.Id == id);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddGenre(string id)
        {
            if (!MovieExists(id))
            {
                return this.NotFound();
            }

            var movie = await this._dbContext.Movies.FindAsync(id);
            var movieGenresViewModel = this._mapper.Map<Movie, MovieAddGenreViewModel>(movie);

            return await Task.Run(() => this.View(movieGenresViewModel));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddGenre(MovieAddGenreViewModel viewModel)
        {
            if (!this.MovieExists(viewModel.Id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var genre = await this._dbContext.Genres.FirstOrDefaultAsync(x => x.Name == viewModel.Name);
                var movieGenre = new MovieGenre()
                {
                    MovieId = viewModel.Id,
                    Genre = genre
                };
                var movie = await this._dbContext.Movies.FindAsync(viewModel.Id);
                movie.MovieGenres.Add(movieGenre);
                this._dbContext.Update(movie);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignPerson(string id)
        {
            var movie = await this._dbContext.Movies.FindAsync(id);

            var moviePeopleIds = await this._dbContext
                .MoviePeople
                .Where(mp => mp.MovieId == id)
                .Select(mp => mp.PersonId)
                .Distinct()
                .ToListAsync();

            var peopleIds = await this._dbContext
                                    .People
                                    .Select(p => p.Id)
                                    .ToListAsync();

            foreach (var personId in moviePeopleIds)
            {
                peopleIds.Remove(personId);
            }

            var peopleToAssign = await this._dbContext
                .People
                .Where(x => peopleIds.Contains(x.Id))
                .ToListAsync();

            var movieWithPeopleToAssignViewModel = this._mapper.Map<Movie, MovieWithPeopleToAssignViewModel>(movie);
            var personToAssignViewModels = this._mapper.Map<IEnumerable<Person>, IEnumerable<PersonAssignViewModel>>(peopleToAssign);

            movieWithPeopleToAssignViewModel.PersonToAssignViewModels = personToAssignViewModels;

            return await Task.Run(() => this.View(movieWithPeopleToAssignViewModel));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignPerson(AssignPersonToMovieViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                if (this.MovieExists(viewModel.MovieId)
                    && this.PersonExists(viewModel.PersonId))
                {
                    var moviePerson = this._mapper.Map<AssignPersonToMovieViewModel, MoviePerson>(viewModel);
                    await this._dbContext.MoviePeople.AddAsync(moviePerson);
                    await this._dbContext.SaveChangesAsync();

                    return this.RedirectToAction("AssignPerson", "Movies", new { id = viewModel.MovieId });
                }
            }

            return await Task.Run(() => this.View());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UnassignPerson(string id)
        {
            var movie = await this._dbContext.Movies.FindAsync(id);

            var peopleToUnassign = await this._dbContext
                .MoviePeople
                .Where(x => x.MovieId == id)
                .Select(mp => mp.Person)
                .Distinct()
                .ToListAsync();

            var movieWithPeopleToUnassignViewModel = this._mapper.Map<Movie, MovieWithPeopleToUnassignViewModel>(movie);
            var personToUnassignViewModels = this._mapper.Map<IEnumerable<Person>, IEnumerable<PersonAssignViewModel>>(peopleToUnassign);

            movieWithPeopleToUnassignViewModel.PersonToAssignViewModels = personToUnassignViewModels;

            return await Task.Run(() => this.View(movieWithPeopleToUnassignViewModel));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UnassignPerson(UnassignPersonFromMovieViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                if (this.MovieExists(viewModel.MovieId)
                    && this.PersonExists(viewModel.PersonId))
                {
                    var moviePerson = await this._dbContext
                                    .MoviePeople
                                    .FirstOrDefaultAsync(mp => mp.MovieId == viewModel.MovieId
                                                                     && mp.PersonId == viewModel.PersonId);

                    this._dbContext.Remove(moviePerson);
                    await this._dbContext.SaveChangesAsync();

                    return this.RedirectToAction("UnassignPerson", "Movies", new { id = viewModel.MovieId });
                }
            }

            return await Task.Run(() => this.View());
        }
    }
}
