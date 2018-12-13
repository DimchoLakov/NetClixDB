namespace NetPhlixDB.Data.Models
{
    using System;

    public class Actor : BaseModel<string>
    {
        public Actor()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
