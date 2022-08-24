using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Models;

namespace PersonalExpenses
{
    public class PEcontext : DbContext
    {
        public DbSet<Cash> Cash => Set<Cash>();
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<Income> Incomes => Set<Income>();
        public DbSet<IncomeInfo> IncomesInfo => Set<IncomeInfo>();
        public DbSet<Expense> Expenses => Set<Expense>();
        public DbSet<ExpensesInfo> ExpensesInfo => Set<ExpensesInfo>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PersonalExpenses;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cash>().HasMany(c => c.IncomeInfos).WithOne(i => i.Cash);

            modelBuilder.Entity<Card>().HasMany(c => c.IncomesInfo).WithMany(i => i.Cards);

            modelBuilder.Entity<Income>().HasMany(i => i.IncomesInfo).WithOne(i => i.Income);

            modelBuilder.Entity<IncomeInfo>().HasOne(i => i.Income).WithMany(i => i.IncomesInfo);


        }
    }
}
