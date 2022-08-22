using PersonalExpenses.Wallets;

namespace PersonalExpenses.Expenses
{
    public class EntertaimentsExp : Expense
    {
        public EntertaimentsExp(decimal amount, int cardId) : base(amount, cardId)
        {
            ExpenseDate = DateTime.Now;
        }
    }
}
