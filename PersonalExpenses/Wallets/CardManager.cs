using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Income;

namespace PersonalExpenses.Wallets
{
    public class CardManager
    {
        private readonly AppContext db;
        private Card card;
        private Salary salary;

        public CardManager()
        {
            db = new AppContext();
        }

        public async void AddCard(string name)
        {
            card = new Card() { Name = name };
            db.Cards.Add(card);
        }

        public async void AddIncome(decimal amount, int cardId)
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
