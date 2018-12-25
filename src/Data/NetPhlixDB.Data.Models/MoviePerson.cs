namespace NetPhlixDB.Data.Models
{
    public class MoviePerson : BaseModel<string>
    {
        public string MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public string PersonId { get; set; }
        public virtual Person Person { get; set; }

        public string EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
