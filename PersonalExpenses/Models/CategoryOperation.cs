
namespace PersonalExpenses.Models
{
    public class CategoryOperation
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? WalletId { get; set; }
        public Wallet Wallet { get; set; }

        public override string ToString()
        {
            return $"Кошелёк: {Wallet.WalletType.Name} Сумма: {Sum}, Дата: {Date},";
        }
    }
}
