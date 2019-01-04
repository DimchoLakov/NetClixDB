using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.CreatedOn)
                .HasDefaultValue(DateTime.UtcNow);

            builder
                .HasMany(x => x.Articles)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId);

            builder
                .HasMany(x => x.Reviews)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
