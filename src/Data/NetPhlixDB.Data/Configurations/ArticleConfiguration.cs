using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.CreatedOn)
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
