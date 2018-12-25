using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.DateAdded)
                .HasDefaultValue(DateTime.UtcNow);

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.MovieId);
        }
    }
}
