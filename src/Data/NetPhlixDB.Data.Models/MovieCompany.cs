namespace NetPhlixDB.Data.Models
{
    public class MovieCompany
    {
        public string MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public string CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
