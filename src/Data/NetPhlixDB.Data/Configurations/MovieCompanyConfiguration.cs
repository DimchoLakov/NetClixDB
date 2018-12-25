using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Data.Configurations
{
    public class MovieCompanyConfiguration : IEntityTypeConfiguration<MovieCompany>
    {
        public void Configure(EntityTypeBuilder<MovieCompany> builder)
        {
            builder
                .HasKey(x => new { x.MovieId, x.CompanyId });

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.MovieCompanies)
                .HasForeignKey(x => x.MovieId);

            builder
                .HasOne(x => x.Company)
                .WithMany(x => x.CompanyMovies)
                .HasForeignKey(x => x.CompanyId);
        }
    }
}
