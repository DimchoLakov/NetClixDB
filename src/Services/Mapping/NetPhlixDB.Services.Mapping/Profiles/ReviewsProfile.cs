using AutoMapper;
using NetPhlixDb.Data.ViewModels.Reviews;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Services.Mapping.Profiles
{
    public class ReviewsProfile : Profile
    {
        public ReviewsProfile()
        {
            CreateMap<Review, AddReviewViewModel>()
                .ReverseMap();
        }
    }
}
