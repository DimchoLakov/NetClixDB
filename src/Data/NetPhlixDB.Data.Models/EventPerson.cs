namespace NetPhlixDB.Data.Models
{
    public class EventPerson
    {
        public string EventId { get; set; }
        public virtual Event Event { get; set; }

        public string PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
