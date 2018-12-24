using System;

namespace NetPhlixDB.Data.Models
{
    public class Article : BaseModel<string>
    {
        public Article()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}
