using GameAPI.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.DataLayer
{
    public class StoreContext : DbContext
    {
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
