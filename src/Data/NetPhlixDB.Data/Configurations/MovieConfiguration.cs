using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDB.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.MovieType)
                .HasConversion(
                    x => x.ToString(),
                    x => (MovieType)Enum.Parse(typeof(MovieType), x, true));
            builder
                .Property(x => x.Language)
                .HasConversion(
                    x => x.ToString(),
                    x => (Language)Enum.Parse(typeof(Language), x, true));
        }
    }
}
