using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NetPhlixDB.Data
{
    public class NetPhlixDbContextFactory : IDesignTimeDbContextFactory<NetPhlixDbContext>
    {
        public NetPhlixDbContext CreateDbContext(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var goThreeDirsBack = "../../../";
            var webDirectory = "Web/NetPhlixDB.Web/";
            var fullPath = Path.GetFullPath(currentDirectory + goThreeDirsBack + webDirectory);

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(fullPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<NetPhlixDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies(true);

            return new NetPhlixDbContext(optionsBuilder.Options);
        }
    }
}
