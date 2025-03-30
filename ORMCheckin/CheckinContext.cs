using Microsoft.EntityFrameworkCore;
using ORMCheckin.Models;

namespace ORMCheckin
{
    internal class CheckinContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<UserCheckin> UserCheckins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=MARSELA-ASYSTEM\SQLEXPRESS;Database=Checkin;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
    }
}
