using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Web.Middlewares
{
    public class SeedRolesMiddleware
    {
        private readonly RequestDelegate _next;

        public SeedRolesMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IServiceProvider serviceProvider, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var dbContext = serviceProvider.GetService<NetPhlixDbContext>();

            if (!dbContext.Roles.Any())
            {
                await this.SeedRoles(userManager, roleManager);
            }

            await this._next(httpContext);
        }

        private async Task SeedRoles(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));
        }
    }
}
