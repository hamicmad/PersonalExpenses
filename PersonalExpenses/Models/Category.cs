

using PersonalExpenses.Enums;

namespace PersonalExpenses.Models
{
    public class Category
    {
        public int Id { get; set; }
        public Types Type { get; set; }
        public string Name { get; set; }

        public List<CategoryOperation> CategoryOperations { get; set; } = new();

        public Category(string name, Types type)
        {
            Name = name;
            Type = type;
        }
    }

    public class CategoryOperation
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }

        public CategoryOperation(decimal sum, int categoryId, int walletId)
        {
            Sum = sum;
            Date = DateTime.Now;
            CategoryId = categoryId;
            WalletId = walletId;
        }

        public override string ToString()
        {
            return $"Кошелёк: {Wallet.WalletType.Name} Сумма: {Sum}, Дата: {Date},";
        }
    }
}
