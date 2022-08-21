
namespace PersonalExpenses.Wallets
{
    public class Cash
    {
        public decimal CashBalance { get; set; }

        public void AddIncome(decimal amount)
        {
            CashBalance += amount;
        }

        public void AddExpense(decimal amount)
        {
            CashBalance -= amount;
        }
    }
}
