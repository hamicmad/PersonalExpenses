using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Models;

namespace PersonalExpenses
{
    public class PEcontext : DbContext
    {
        public DbSet<Wallet> Wallets => Set<Wallet>();
        public DbSet<WalletType> WalletTypes => Set<WalletType>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<CategoryOperation> CategoryOperations => Set<CategoryOperation>();

        public PEcontext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PersonalExpenses;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Wallet>(e =>
            //{
            //    e.HasOne(w => w.WalletType).WithOne(w => w.Wallet);
            //    e.HasMany(w => w.CategoryOperations).WithOne(c => c.Wallet);
            //});
            modelBuilder.Entity<WalletType>(e =>
            {
                e.Property(w => w.Currency).HasConversion<string>();
            });
            //modelBuilder.Entity<Category>(e => e.HasMany(c => c.CategoryOperations).WithOne(c => c.Category));

            //modelBuilder.Entity<CategoryOperation>(e =>
            //{
            //    e.HasOne(c => c.Wallet).WithMany(w => w.CategoryOperations);
            //    e.HasOne(c => c.Category).WithMany(w => w.CategoryOperations);
            //});
        }
    }
}
