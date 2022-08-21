using PersonalExpenses.Wallets;

namespace PersonalExpenses.Income
{
    public class Salary
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateOfSalary { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public Salary() { }
        public Salary(decimal salary, int cardId)
        {
            Balance = salary;
            DateOfSalary = DateTime.Now;
            CardId = cardId;
        }


    }
}
