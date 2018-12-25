using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDB.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.GenreType)
                .HasConversion(
                    x => x.ToString(),
                    x => (GenreType)Enum.Parse(typeof(GenreType), x, true));
        }
    }
}
