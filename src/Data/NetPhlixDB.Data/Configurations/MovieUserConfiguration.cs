using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Data.Configurations
{
    public class MovieUserConfiguration : IEntityTypeConfiguration<MovieUser>
    {
        public void Configure(EntityTypeBuilder<MovieUser> builder)
        {
            builder
                .HasKey(x => new { x.MovieId, x.UserId });

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.MovieUsers)
                .HasForeignKey(x => x.MovieId);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.FavoriteMovies)
                .HasForeignKey(x => x.UserId);
        }
    }
}
