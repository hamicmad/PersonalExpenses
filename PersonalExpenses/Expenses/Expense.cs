using PersonalExpenses.Wallets;

namespace PersonalExpenses.Expenses
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal ExpenseSum { get; set; }
        public DateTime ExpenseDate { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }
        public Cash Cash { get; set; }

        public Expense() { }

        public Expense(decimal amount, int cardId)
        {
            ExpenseSum = amount;
            ExpenseDate = DateTime.Now;
            CardId = cardId;
        }

        public override string ToString()
        {
            return $"Id: {Id}  Сумма: {ExpenseSum}   Дата: {ExpenseDate}";
        }
    }
}