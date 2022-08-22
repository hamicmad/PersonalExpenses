using PersonalExpenses.Expenses;
using PersonalExpenses.Income;

namespace PersonalExpenses.Wallets
{
    public class Cash
    {
        public int Id { get; set; }
        public decimal Balance { get; set; } = 0;

        public List<Salary> Salaries { get; set; } = new();
        public List<ProductsExp> ProductsExps { get; set; } = new();
        public List<EntertaimentsExp> EntertaimentsExps { get; set; } = new();
    }
}
