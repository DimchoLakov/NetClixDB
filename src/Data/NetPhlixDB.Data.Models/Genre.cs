namespace NetPhlixDB.Data.Models
{
    using System;

    public class Genre : BaseModel<string>
    {
        public Genre()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
