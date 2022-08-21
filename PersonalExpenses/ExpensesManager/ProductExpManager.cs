using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Expenses;
using PersonalExpenses.Wallets;

namespace PersonalExpenses.ExpensesManager
{
    public class ProductExpManager
    {
        private readonly ProductsExpense prodExp = new ProductsExpense();
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

    }
}
