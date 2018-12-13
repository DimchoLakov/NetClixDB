namespace NetPhlixDB.Data.Models
{
    public class MovieActor : BaseModel<string>
    {
        public string MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public string ActorId { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
