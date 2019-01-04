namespace NetPhlixDB.Data.Models
{
    public class MovieGenre
    {
        public string MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public string GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
