using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services;
using NetPhlixDB.Services.Contracts;
using NetPhlixDB.Services.Mapping.Profiles;
using NetPhlixDB.Services.Mapping.Profiles.Admin;
using Xunit;

namespace NetPhlixDB.Tests
{
    public class MoviesServiceTests
    {
        private readonly NetPhlixDbContext _dbContext;
        private readonly IMapper _mapper;

        public MoviesServiceTests()
        {
            var options = new DbContextOptionsBuilder<NetPhlixDbContext>()
                .UseInMemoryDatabase("Test")
                .Options;
            this._dbContext = new NetPhlixDbContext(options);
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
                        typeof(AdminProfile)
                    );
                });
            this._mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task MovieExistsShouldReturnFalseWithNullParameter()
        {
            var service = new Mock<IMoviesService>();

            var movieExists = await service.Object.MovieExists(null);

            Assert.False(movieExists);
        }

        [Fact]
        public async Task GetAllCountShouldReturnCorrectNumberOfMovies()
        {
            var options = new DbContextOptionsBuilder<NetPhlixDbContext>()
                .UseInMemoryDatabase("Test")
                .Options;
            var dbContext = new NetPhlixDbContext(options);

            await dbContext.Movies.AddRangeAsync(
                new Movie(),
                new Movie(),
                new Movie()
            );
            await dbContext.SaveChangesAsync();

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
                        typeof(AdminProfile)
                    );
                });
            IMapper mapper = mappingConfig.CreateMapper();

            var service = new MoviesService(mapper, dbContext);
            var allMovies = await service.GetAll();

            Assert.Equal(3, allMovies.Count());
        }

        [Fact]
        public async Task GetByIdExistingShouldReturnNotNullObject()
        {
            var options = new DbContextOptionsBuilder<NetPhlixDbContext>()
                .UseInMemoryDatabase("Test")
                .Options;
            var dbContext = new NetPhlixDbContext(options);
            await dbContext.Movies.AddAsync(
                    new Movie()
                    { Id = "first" }
                );
            await dbContext.SaveChangesAsync();

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
                        typeof(AdminProfile)
                    );
                });
            IMapper mapper = mappingConfig.CreateMapper();

            var service = new MoviesService(mapper, dbContext);
            var movie = await service.GetById("first");

            Assert.NotNull(movie);
        }

        [Fact]
        public async Task GetMovieTitleByIdShouldReturnCorrectTitle()
        {
            var options = new DbContextOptionsBuilder<NetPhlixDbContext>()
                .UseInMemoryDatabase("Test")
                .Options;
            var dbContext = new NetPhlixDbContext(options);
            await dbContext.Movies.AddAsync(
                new Movie()
                { Id = "first", Title = "title" }
            );
            await dbContext.SaveChangesAsync();

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
                        typeof(AdminProfile)
                    );
                });
            IMapper mapper = mappingConfig.CreateMapper();

            var service = new MoviesService(mapper, dbContext);
            var title = await service.GetMovieTitleById("first");

            Assert.Equal("title", title);
        }
    }
}
