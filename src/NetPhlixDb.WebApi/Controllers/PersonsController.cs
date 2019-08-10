using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPhlixDb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly NetPhlixDbContext dbContext;

        public PersonsController(NetPhlixDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // api/persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            var persons = await this.dbContext.People.ToListAsync();
            return persons;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(string id)
        {
            var person = await this.dbContext.People.FirstOrDefaultAsync(x => x.Id == id);
            return person;
        }
    }
}