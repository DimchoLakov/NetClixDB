using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetPhlixDb.Data.ViewModels.DTOs;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDb.Data.ViewModels.Events;
using NetPhlixDB.Services.Mapping.Profiles;
using Newtonsoft.Json;
using TMDbLib.Client;
using TMDbLib.Objects.Authentication;
using TMDbLib.Objects.Movies;
using Movie = NetPhlixDB.Data.Models.Movie;

namespace Sandbox
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;
                await SandboxCode(serviceProvider);
            }
        }

        private static async Task SandboxCode(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService<NetPhlixDbContext>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));

            TMDbClient tmDbClient = new TMDbClient("");
            tmDbClient.GetConfig();

            var mov1 = await tmDbClient.GetMovieListsAsync(2);
            var col1 = await tmDbClient.GetCollectionAsync(1);
            var genres = await tmDbClient.GetMovieGenresAsync();
            var people = await tmDbClient.GetChangesPeopleAsync();
            var person = await tmDbClient.GetPersonAsync(1);
            var network = await tmDbClient.GetNetworkAsync(1);

            var jsonSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented, Culture = CultureInfo.InvariantCulture };

            var mapper = (IMapper)serviceProvider.GetService(typeof(IMapper));

            for (int i = 1; i < 200_000; i++)
            {
                var movie = await tmDbClient.GetMovieAsync(i, MovieMethods.Images | MovieMethods.Credits | MovieMethods.Reviews);

                if (movie.Credits != null)
                {
                    var cast = movie.Credits.Cast.First();
                    var crew = movie.Credits.Crew.First();
                }

                if (movie.Reviews?.TotalResults > 0)
                {
                    var review = movie.Reviews.Results.First();
                }

                if (movie.Images != null)
                {
                    foreach (var imagePoster in movie.Images.Posters)
                    {
                        
                        var img = tmDbClient.GetImageUrl("w500", imagePoster.FilePath);
                    }
                }
            }

        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var temp = Directory.GetCurrentDirectory();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            var mappingConfig = new MapperConfiguration(
                mc =>
                {
                    mc.AddProfiles(
                        typeof(SandboxProfile)
                    );
                });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<NetPhlixDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
