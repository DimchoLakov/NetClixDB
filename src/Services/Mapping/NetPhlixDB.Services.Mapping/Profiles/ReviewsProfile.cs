using AutoMapper;
using NetPhlixDb.Data.ViewModels.Binding.Reviews;
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
