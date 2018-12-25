using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.MoviePeople)
                .WithOne(x => x.Event)
                .HasForeignKey(x => x.EventId);
        }
    }
}
