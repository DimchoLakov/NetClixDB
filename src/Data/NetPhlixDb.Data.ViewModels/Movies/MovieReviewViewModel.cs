using System;

namespace NetPhlixDb.Data.ViewModels.Movies
{
    public class MovieReviewViewModel
    {
        public string Title { get; set; }

        public string AddedBy { get; set; }

        public string Content { get; set; }

        public DateTime DateAdded { get; set; }

        public double Rating { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserAvatar { get; set; }
    }
}
