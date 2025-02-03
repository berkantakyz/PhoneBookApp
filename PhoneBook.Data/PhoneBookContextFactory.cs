using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PhoneBook.Data
{
    namespace PhoneBook.Data
    {
        public class PhoneBookContextFactory : IDesignTimeDbContextFactory<PhoneBookContext>
        {
            public PhoneBookContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<PhoneBookContext>();

                var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                var apiDirectory = Path.Combine(projectDirectory, "PhoneBook.Api");

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(apiDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("cs");

                optionsBuilder.UseNpgsql(connectionString);

                return new PhoneBookContext(optionsBuilder.Options);
            }
        }
    }
}