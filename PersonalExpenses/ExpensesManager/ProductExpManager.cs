using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Expenses;
using PersonalExpenses.Wallets;

namespace PersonalExpenses.ExpensesManager
{
    public class ProductExpManager
    {
        private readonly AppContext db;

        public ProductExpManager()
        {
            db = new AppContext();
        }

        public async void AddCardExpense(int cardId, decimal amount)
        {
            var card = await db.Cards.FirstOrDefaultAsync(c => c.Id == cardId);
            if (card != null)
            {
                card.Balance -= amount;
                var expense = new ProductsExpense(amount);
                await db.ProductsExpenses.AddAsync(expense);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<ProductsExpense>> ReadExpenses()
        {
            return await db.ProductsExpenses.ToListAsync();
        }

        public async Task Change(int expId, int cardId, decimal sum)
        {
            var exp = await db.ProductsExpenses.FirstOrDefaultAsync(e => e.Id == expId);
            var card = await db.Cards.FirstOrDefaultAsync(c => c.Id == cardId);
            if(exp != null && card != null)
            {
                card.Balance += exp.ExpenseSum;
                exp.ExpenseSum = sum;
                card.Balance -= sum;
                await db.SaveChangesAsync();
            }    
        }
        public async Task Delete(int expId,int cardId)
        {
            var exp = await db.ProductsExpenses.FirstOrDefaultAsync(e => e.Id == expId);
            var card = await db.Cards.FirstOrDefaultAsync(c => c.Id == cardId);
            if(exp != null && card != null)
            {
                card.Balance += exp.ExpenseSum;
                db.ProductsExpenses.Remove(exp);
                await db.SaveChangesAsync();
            }
        }
    }
}
