using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Binding.Admin.Users;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly NetPhlixDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public UsersController(NetPhlixDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> All()
        {
            var allUsers = await this._dbContext
                .Users
                .Select(x => new UserViewModel()
                {
                    Id = x.Id,
                    Email = x.Email
                })
                .ToListAsync();

            return View(allUsers);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PromoteUser(UserIdViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await this._userManager.Users.FirstOrDefaultAsync(x => x.Id == model.Id);

                var role = await this._userManager.GetRolesAsync(user);

                var userRole = await this._dbContext.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == model.Id);
                this._dbContext.UserRoles.Remove(userRole);

                await this._userManager.AddToRoleAsync(user, "Admin");

                return RedirectToAction("All", "Users");
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DemoteUser(UserIdViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await this._userManager.Users.FirstOrDefaultAsync(x => x.Id == model.Id);

                var role = await this._userManager.GetRolesAsync(user);

                var userRole = await this._dbContext.UserRoles.FirstOrDefaultAsync(x => x.UserId == model.Id);
                this._dbContext.UserRoles.Remove(userRole);

                await this._userManager.AddToRoleAsync(user, "User");

                return RedirectToAction("All", "Users");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}