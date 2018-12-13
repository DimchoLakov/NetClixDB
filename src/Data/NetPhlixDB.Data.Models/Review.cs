namespace NetPhlixDB.Data.Models
{
    using System;

    public class Review : BaseModel<string>
    {
        public Review()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
