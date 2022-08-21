using PersonalExpenses.Wallets;

namespace PersonalExpenses.Expenses
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal ExpenseSum { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}