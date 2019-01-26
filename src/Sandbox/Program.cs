using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetPhlixDb.Data.ViewModels.DTOs;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Mapping.Profiles;
using Newtonsoft.Json;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;
using Movie = NetPhlixDB.Data.Models.Movie;

namespace Sandbox
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;
                SandboxCode(serviceProvider);
            }
        }

        private static void SandboxCode(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService<NetPhlixDbContext>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //TMDbClient tmDbClient = new TMDbClient("yourApiKey");
            
            var jsonSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented, Culture = CultureInfo.InvariantCulture };

            var mapper = (IMapper)serviceProvider.GetService(typeof(IMapper));
            for (int i = 300_000; i < 300_100; i++)
            {
                var url = "https://api.themoviedb.org/3/movie/" + $"{i}" + "?api_key=yourApiKey";
                //client.BaseAddress = new Uri(url);
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    //var tmdMovie = tmDbClient.GetMovieAsync(i, MovieMethods.Videos | MovieMethods.Images).Result;
                    //var tmdbVideos = tmdMovie.Videos.Results;

                    //Console.WriteLine($"Movie name: {tmdMovie.Title}");

                    // Parse the response body.
                    var json = response.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine(json);

                    var movieDto = new MovieDto();
                    try
                    {
                        movieDto = JsonConvert.DeserializeObject<MovieDto>(json, jsonSettings);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    var movieExists = dbContext.Movies.FirstOrDefault(x => x.Title == movieDto.Title) != null;
                    if (movieExists)
                    {
                        continue;
                    }

                    var movie = mapper.Map<MovieDto, Movie>(movieDto);
                    var genres = mapper.Map<IEnumerable<MovieGenreDto>, IEnumerable<Genre>>(movieDto.MovieGenreDtos);
                    var companies = mapper.Map<IEnumerable<MovieCompanyDto>, IEnumerable<Company>>(movieDto.MovieCompanyDtos);

                    var movieGenres = new List<MovieGenre>();
                    var movieCompanies = new List<MovieCompany>();

                    foreach (var genre in genres)
                    {
                        var g = dbContext.Genres.FirstOrDefault(x => x.Name == genre.Name);
                        var genreExists = g != null;

                        if (!genreExists)
                        {
                            dbContext.Genres.Add(genre);
                            dbContext.SaveChanges();

                            g = dbContext.Genres.FirstOrDefault(x => x.Name == genre.Name);
                        }

                        movieGenres.Add(new MovieGenre()
                        {
                            GenreId = g.Id,
                            Movie = movie
                        });
                    }

                    foreach (var company in companies)
                    {
                        var c = dbContext.Companies.FirstOrDefault(x => x.Name == company.Name);
                        var companyExists = c != null;

                        if (!companyExists)
                        {
                            dbContext.Companies.Add(company);
                            dbContext.SaveChanges();

                            c = dbContext.Companies.FirstOrDefault(x => x.Name == company.Name);
                        }

                        movieCompanies.Add(new MovieCompany()
                        {
                            CompanyId = c.Id,
                            Movie = movie
                        });
                    }

                    movie.MovieGenres = movieGenres;
                    movie.MovieCompanies = movieCompanies;
                    
                    dbContext.Movies.Add(movie);
                    dbContext.SaveChanges();

                    var moviesCount = dbContext.Movies.Count();

                    Console.WriteLine($"Movies count: {moviesCount}");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
            client.Dispose();

        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
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
