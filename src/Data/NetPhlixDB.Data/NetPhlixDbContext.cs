using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetPhlixDB.Data.Configurations;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Data
{
    public class NetPhlixDbContext : IdentityDbContext<User>
    {
        public NetPhlixDbContext(DbContextOptions<NetPhlixDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieCompany> MovieCompanies { get; set; }
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }
        public virtual DbSet<MoviePerson> MoviePeople { get; set; }
        public virtual DbSet<MovieUser> MovieUsers { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ArticleConfiguration())
                .ApplyConfiguration(new CompanyConfiguration())
                .ApplyConfiguration(new EventConfiguration())
                .ApplyConfiguration(new GenreConfiguration())
                .ApplyConfiguration(new MovieCompanyConfiguration())
                .ApplyConfiguration(new MovieConfiguration())
                .ApplyConfiguration(new MovieGenreConfiguration())
                .ApplyConfiguration(new MoviePersonConfiguration())
                .ApplyConfiguration(new MovieUserConfiguration())
                .ApplyConfiguration(new PersonConfiguration())
                .ApplyConfiguration(new ReviewConfiguration())
                .ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
