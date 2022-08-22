using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Expenses;

namespace PersonalExpenses.ExpensesManager
{
    public class EntertaimsExpManager
    {
        private readonly AppContext db;

        public EntertaimsExpManager()
        {
            db = new AppContext();
        }

        public async Task AddCardExpense(int cardId, decimal amount)
        {
            var card = await db.Cards.FirstOrDefaultAsync(c => c.Id == cardId);
            if (card != null)
            {
                card.Balance -= amount;
                var expense = new EntertaimentsExp(amount, card.Id);
                await db.EntertaimentsExps.AddAsync(expense);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<EntertaimentsExp>> ReadExpenses()
        {
            return await db.EntertaimentsExps.ToListAsync();
        }

        public async Task Change(int expId, int cardId, decimal sum)
        {
            var exp = await db.EntertaimentsExps.FirstOrDefaultAsync(e => e.Id == expId);
            var card = await db.Cards.FirstOrDefaultAsync(c => c.Id == cardId);
            if (exp != null && card != null)
            {
                card.Balance += exp.ExpenseSum;
                exp.ExpenseSum = sum;
                card.Balance -= sum;
                await db.SaveChangesAsync();
            }
        }
        public async Task Delete(int expId, int cardId)
        {
            var exp = await db.EntertaimentsExps.FirstOrDefaultAsync(e => e.Id == expId);
            var card = await db.Cards.FirstOrDefaultAsync(c => c.Id == cardId);
            if (exp != null && card != null)
            {
                card.Balance += exp.ExpenseSum;
                db.EntertaimentsExps.Remove(exp);
                await db.SaveChangesAsync();
            }
        }
    }
}
