using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Data.Configurations
{
    public class MoviePersonConfiguration : IEntityTypeConfiguration<MoviePerson>
    {
        public void Configure(EntityTypeBuilder<MoviePerson> builder)
        {
            builder
                .HasKey(x => new { x.MovieId, x.PersonId });

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.MoviePeople)
                .HasForeignKey(x => x.MovieId);

            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.PersonMovies)
                .HasForeignKey(x => x.PersonId);
        }
    }
}
