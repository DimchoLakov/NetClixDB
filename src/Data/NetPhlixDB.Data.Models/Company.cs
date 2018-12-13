namespace NetPhlixDB.Data.Models
{
    using System;

    public class Company : BaseModel<string>
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
