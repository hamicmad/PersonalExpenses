using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Expenses;
using PersonalExpenses.Income;
using PersonalExpenses.Wallets;

namespace PersonalExpenses
{
    public class AppContext : DbContext
    {
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<ProductsExp> ProductsExpenses => Set<ProductsExp>();
        public DbSet<Salary> Salaries => Set<Salary>();
        public DbSet<EntertaimentsExp> EntertaimentsExps => Set<EntertaimentsExp>();

        public AppContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AppEFdb;Trusted_Connection=True");
        }
    }
}
