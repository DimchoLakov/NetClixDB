namespace NetPhlixDB.Data.Models
{
    using System;

    public class Review : BaseModel<string>
    {
        public Review()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }

        public string AddedBy { get; set; }

        public string Content { get; set; }

        public DateTime DateAdded { get; set; }

        public double Rating { get; set; }

        public string MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
