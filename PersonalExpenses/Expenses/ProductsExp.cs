using PersonalExpenses.Wallets;

namespace PersonalExpenses.Expenses
{
    public class ProductsExp : Expense
    {
        public ProductsExp(decimal amount, int cardId) : base(amount, cardId)
        {
            ExpenseDate = DateTime.Now;
        }
    }
}
