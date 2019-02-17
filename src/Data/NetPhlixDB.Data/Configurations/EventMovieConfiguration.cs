using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Data.Configurations
{
    public class EventMovieConfiguration : IEntityTypeConfiguration<EventMovie>
    {
        public void Configure(EntityTypeBuilder<EventMovie> builder)
        {
            builder
                .HasKey(x => new { x.EventId, x.MovieId });

            builder
                .HasOne(x => x.Event)
                .WithMany(x => x.EventMovies)
                .HasForeignKey(x => x.EventId);

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.MovieEvents)
                .HasForeignKey(x => x.MovieId);
        }
    }
}
