

namespace PersonalExpenses.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<IncomeInfo> IncomesInfo { get; set; } = new();

        public Income(string name)
        {
            Name = name;
        }
    }

    public class IncomeInfo
    {
        public int Id { get; set; }
        public decimal Sum { get; set; } = 0m;
        public DateTime IncomeDate { get; set; }

        public int IncomeId { get; set; }
        public Income Income { get; set; }
        public List<Card> Cards { get; set; } = new();
        public int? CashId { get; set; }
        public Cash Cash { get; set; }

        public IncomeInfo(decimal balance)
        {
            Sum = balance;
            IncomeDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Id {Id}, Сумма {Sum}, Дата {IncomeDate}.";
        }
    }
}
