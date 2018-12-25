using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDB.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.PersonRole)
                .HasConversion(
                    x => x.ToString(),
                    x => (PersonRole)Enum.Parse(typeof(PersonRole), x, true));
        }
    }
}
