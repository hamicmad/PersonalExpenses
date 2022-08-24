
namespace PersonalExpenses.Models
{
    public class Cash
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public List<IncomeInfo> IncomeInfos { get; set; } = new();
    }
}
