namespace NetPhlixDB.Data.Models
{
    public class EventMovie
    {
        public string EventId { get; set; }
        public virtual Event Event { get; set; }

        public string MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
