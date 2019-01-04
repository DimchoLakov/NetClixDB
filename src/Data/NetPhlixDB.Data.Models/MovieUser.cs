namespace NetPhlixDB.Data.Models
{
    public class MovieUser
    {
        public string MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
