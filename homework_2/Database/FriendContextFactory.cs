using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace homework_2.Database
{
    public class FriendContextFactory : IDesignTimeDbContextFactory<FriendContext>
    {
        public FriendContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FriendContext>();

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            string? connectionString = config.GetConnectionString("FriendDb");
            optionsBuilder.UseSqlServer(connectionString);
            return new FriendContext(optionsBuilder.Options);
        }
    }
}
