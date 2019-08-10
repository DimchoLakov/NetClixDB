using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services;
using NetPhlixDB.Services.Contracts;
using NetPhlixDB.Services.Mapping.Profiles;
using NetPhlixDB.Services.Mapping.Profiles.Admin;
using NetPhlixDB.Web.Middlewares;
using NetPhlixDB.Web.Services;

namespace NetPhlixDB.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<NetPhlixDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"))
                    .UseLazyLoadingProxies());

            services.AddIdentity<User, IdentityRole>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequiredUniqueChars = 0;
                })
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<NetPhlixDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication();

            //services.AddAuthentication().AddFacebook(facebookOptions =>
            //{
            //    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
            //    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            //});

            //services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            services.AddTransient<IMoviesService, MoviesService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IReviewsService, ReviewsService>();
            services.AddTransient<ICompaniesService, CompaniesService>();
            services.AddTransient<IPeopleService, PeopleService>();
            services.AddTransient<IEventsService, EventsService>();

            var mappingConfig = new MapperConfiguration(
                mc =>
                {
                    mc.AddProfiles(
                        typeof(MoviesProfile), 
                        typeof(UsersProfile),
                        typeof(CompaniesProfile),
                        typeof(ReviewsProfile),
                        typeof(PeopleProfile),
                        typeof(EventsProfile),
                        typeof(AdminProfile),
                        typeof(EventMovieProfile),
                        typeof(EventPersonProfile)
                    );
                });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Email settings
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            services.AddMvc(options =>
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //SendGridEmailSender.Execute().Wait();
            env.EnvironmentName = EnvironmentName.Development;
            //env.EnvironmentName = EnvironmentName.Production;

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<NetPhlixDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");

            app.SeedRoles();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
