using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NetPhlixDB.Data
{
    public class NetPhlixDbContextFactory : IDesignTimeDbContextFactory<NetPhlixDbContext>
    {
        public NetPhlixDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NetPhlixDbContext>();
            optionsBuilder
                .UseSqlServer(connectionString:
                    "Server=(LocalDb)\\MSSQLLocalDB;Database=NetPhlixDB;Trusted_Connection=True;MultipleActiveResultSets=true")
                .UseLazyLoadingProxies();

            return new NetPhlixDbContext(optionsBuilder.Options);
        }
    }
}
