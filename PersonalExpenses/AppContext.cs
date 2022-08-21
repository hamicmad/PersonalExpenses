using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Expenses;
using PersonalExpenses.Income;
using PersonalExpenses.Wallets;

namespace PersonalExpenses
{
    public class AppContext : DbContext
    {
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<ProductsExpense> ProductsExpenses => Set<ProductsExpense>();
        public DbSet<Salary> Salaries => Set<Salary>();

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
