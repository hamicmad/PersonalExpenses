using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Income;

namespace PersonalExpenses.Wallets
{
    public class CashManager
    {
        private readonly AppContext db;

        public CashManager()
        {
            db = new AppContext();
        }

        public async Task AddIncome(decimal amount, int cardId)
        {
            var card = await db.Cards.FirstOrDefaultAsync(c => c.Id == cardId);
            if (card != null)
            {
                card.Balance += amount;
                salary = new Salary(amount, card.Id);
                await db.Salaries.AddAsync(salary);
                await db.SaveChangesAsync();
            }
        }
    }
}
