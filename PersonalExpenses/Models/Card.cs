
namespace PersonalExpenses.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Balance { get; set; } 

        public List<IncomeInfo> IncomesInfo { get; set; } = new();

        public Card(string name)
        {
            Name = name;
        }
    }
}
