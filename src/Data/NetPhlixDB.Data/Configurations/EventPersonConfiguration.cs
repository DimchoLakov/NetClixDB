using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Data.Configurations
{
    public class EventPersonConfiguration : IEntityTypeConfiguration<EventPerson>
    {
        public void Configure(EntityTypeBuilder<EventPerson> builder)
        {
            builder
                .HasKey(x => new { x.EventId, x.PersonId });

            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.PersonEvents)
                .HasForeignKey(x => x.PersonId);

            builder
                .HasOne(x => x.Event)
                .WithMany(x => x.EventPeople)
                .HasForeignKey(x => x.EventId);
        }
    }
}
