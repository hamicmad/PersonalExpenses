using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Enums;
using PersonalExpenses.Models;

namespace PersonalExpenses.Controller
{
    public class OperationCntr
    {
        private readonly PEcontext db;

        public OperationCntr()
        {
            db = new PEcontext();
        }

        public async Task Create(decimal sum, int cId, int wId)
        {
            var wallet = await db.Wallets.FirstOrDefaultAsync(c => c.Id == wId);
            var category = await db.Categories.FirstOrDefaultAsync(i => i.Id == cId);

            if (wallet != null && category != null)
            {
                category.CategoryOperations.Add(new CategoryOperation()
                {
                    Sum = sum,
                    Date = DateTime.Now,
                    CategoryId = category.Id,
                    WalletId = wallet.Id,
                });
                if (category.Type == Types.Expense)
                {
                    wallet.Balance -= sum;
                }
                if (category.Type == Types.Income)
                {
                    wallet.Balance += sum;
                }
                await db.SaveChangesAsync();
            }
        }

        public async Task Update(int id, decimal sum)
        {
            var op = await db.CategoryOperations.Include(c => c.Wallet)
                                                .Include(c => c.Category)
                                                .FirstOrDefaultAsync(c => c.Id == id);
            if (op != null)
            {
                if (op.Category.Type == Types.Expense)
                {
                    op.Wallet.Balance += op.Sum;
                    op.Wallet.Balance -= sum;
                    op.Sum = sum;
                }
                if (op.Category.Type == Types.Income)
                {
                    op.Wallet.Balance -= op.Sum;
                    op.Wallet.Balance += sum;
                    op.Sum = sum;
                }
            }
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var op = await db.CategoryOperations.Include(c => c.Category).Include(c => c.Wallet).FirstOrDefaultAsync(c => c.Id == id);

            if (op != null)
            {
                if (op.Category.Type == Types.Expense)
                {
                    op.Wallet.Balance += op.Sum;
                }
                if (op.Category.Type == Types.Income)
                {
                    op.Wallet.Balance -= op.Sum;
                }
                db.CategoryOperations.Remove(op);
                await db.SaveChangesAsync();
            }
        }
    }
}
