using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Admin.Movies;
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
                var genre = await this._dbContext.Genres.FirstOrDefaultAsync(x => x.GenreType == viewModel.GenreType);
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
    }
}
