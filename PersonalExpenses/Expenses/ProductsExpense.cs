using PersonalExpenses.Wallets;

namespace PersonalExpenses.Expenses
{
    public class ProductsExpense : Expense
    {
        public ProductsExpense() { }

        public ProductsExpense(decimal amount)
        {
            ExpenseSum = amount;
            ExpenseDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Id: {Id}  Сумма: {ExpenseSum}   Дата: {ExpenseDate}";
        }
    }
}
