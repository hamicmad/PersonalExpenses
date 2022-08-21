using PersonalExpenses.Expenses;
using PersonalExpenses.Income;

namespace PersonalExpenses.Wallets
{
    public class Card
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Balance { get; set; } = 0;

        public List<Salary> Salaries { get; set; }
    }
}
