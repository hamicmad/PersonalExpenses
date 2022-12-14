using PersonalExpenses.Enums;

namespace PersonalExpenses.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public WalletType WalletType { get; set; }
        public List<CategoryOperation> CategoryOperations { get; set; } = new();
    }

    public class WalletType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Currency Currency { get; set; }

        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
