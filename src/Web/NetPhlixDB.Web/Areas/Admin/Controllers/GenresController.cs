using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Admin.Genres;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenresController : Controller
    {
        private readonly NetPhlixDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(NetPhlixDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var genres = await _context.Genres.OrderBy(x => x.Name.ToString()).ToListAsync();
            var genreViewModels = this._mapper.Map<IEnumerable<Genre>, IEnumerable<IndexGenreViewModel>>(genres);
            return View(genreViewModels);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genre == null)
            {
                return NotFound();
            }

            var genreViewModel = this._mapper.Map<Genre, EditDeleteDetailsGenreViewModel>(genre);

            return View(genreViewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => View());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateGenreViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Genres.FirstOrDefaultAsync(x => x.Name == viewModel.Name) != null)
                {
                    this.ModelState.AddModelError(string.Empty, $"Genre with name '{viewModel.Name}' already exists");
                    return View(viewModel);
                }

                var genre = this._mapper.Map<CreateGenreViewModel, Genre>(viewModel);

                _context.Add(genre);
                await _context.SaveChangesAsync();
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

            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            var genreViewModel = this._mapper.Map<Genre, EditDeleteDetailsGenreViewModel>(genre);

            return View(genreViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditDeleteDetailsGenreViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var genre = this._mapper.Map<EditDeleteDetailsGenreViewModel, Genre>(viewModel);
                try
                {
                    _context.Update(genre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.Id))
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

            var genre = await _context.Genres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genre == null)
            {
                return NotFound();
            }

            var genreViewModel = this._mapper.Map<Genre, EditDeleteDetailsGenreViewModel>(genre);

            return View(genreViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var genre = await _context.Genres.FindAsync(id);
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreExists(string id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }
    }
}
