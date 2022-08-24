

namespace PersonalExpenses.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<ExpensesInfo> ExpensesInfo { get; set; } = new();

        public Expense(string name)
        {
            Name = name;
        }
    }
    public class ExpensesInfo
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime ExpenseDate { get; set; }

        public ExpensesInfo(decimal sum)
        {
            Sum = sum;
            ExpenseDate = DateTime.Now;
        }

        public int ExpenseId { get; set; }
        public Expense Expense { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public Cash Cash { get; set; }

        public override string ToString()
        {
            return $"Id {Id}, Сумма {Sum}, Дата: {ExpenseDate}" ; 
        }
    }
}