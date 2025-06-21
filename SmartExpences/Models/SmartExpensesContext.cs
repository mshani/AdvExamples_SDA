using Microsoft.EntityFrameworkCore;

namespace SmartExpenses.Models
{
    public class SmartExpensesContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Incoming> Incomings { get; set; }

        public SmartExpensesContext(DbContextOptions<SmartExpensesContext> options) : base(options)
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
