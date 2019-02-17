using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Events;
using NetPhlixDB.Data;
using NetPhlixDB.Services;
using NetPhlixDB.Services.Contracts;
using NetPhlixDB.Services.Mapping.Profiles;
using NetPhlixDB.Services.Mapping.Profiles.Admin;
using Xunit;

namespace NetPhlixDB.Tests
{
    public class EventsServiceTests
    {
        private readonly NetPhlixDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMoviesService _moviesService;
        private readonly IPeopleService _peopleService;

        public EventsServiceTests()
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
            this._moviesService = new MoviesService(this._mapper, this._dbContext);
            this._peopleService = new PeopleService(this._dbContext, this._mapper);
        }

        [Fact]
        public async Task CreateEventShouldReturnOne()
        {
            var service = new EventsService(this._dbContext, this._mapper, this._moviesService, this._peopleService);

            var result = await service.CreateEvent(new CreateEventViewModel());

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task GetAllShouldReturnCorrectCount()
        {
            var service = new EventsService(this._dbContext, this._mapper, this._moviesService, this._peopleService);
            await service.CreateEvent(new CreateEventViewModel());
            await service.CreateEvent(new CreateEventViewModel());

            var allEvents = await service.GetAll();
            var count = allEvents.Count();
            
            Assert.Equal(2, count);
        }
    }
}
