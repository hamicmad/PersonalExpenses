using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Models;

namespace PersonalExpenses.Controller
{
    public class CardCntr
    {
        private readonly PEcontext db;

        public CardCntr()
        {
            db = new PEcontext();
        }

        public async Task AddCard(string name)
        {
            var card = new Card(name);
            await db.Cards.AddAsync(card);
            await db.SaveChangesAsync();
        }

        public async Task AddIncome(decimal sum, int cardId, int incId)
        {
            var card = await db.Cards.FirstOrDefaultAsync(c => c.Id == cardId);
            var income = await db.Incomes.FirstOrDefaultAsync(i => i.Id == incId);

            if (card != null && income != null)
            {
                card.Balance += sum;
                income.IncomesInfo.Add(new IncomeInfo(sum));
                await db.SaveChangesAsync();
            }
        }

        public async Task AddExpense(decimal sum, int cardId, int expId)
        {
            var card = await db.Cards.FirstOrDefaultAsync(c => c.Id == cardId);
            var expense = await db.Expenses.FirstOrDefaultAsync(e => e.Id == expId);

            if (card != null && expense != null)
            {
                card.Balance -= sum;
                expense.ExpensesInfo.Add(new ExpensesInfo(sum));
                await db.SaveChangesAsync();
            }
        }
    }
}
