using System.Collections.Generic;

namespace NetPhlixDB.Data.Models
{
    using System;

    public class Company : BaseModel<string>
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CompanyMovies = new List<MovieCompany>();
        }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Details { get; set; }

        public string Logo { get; set; }
        
        public virtual ICollection<MovieCompany> CompanyMovies { get; set; }
    }
}
