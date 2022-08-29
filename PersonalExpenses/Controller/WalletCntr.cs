using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Enums;
using PersonalExpenses.Models;

namespace PersonalExpenses.Controller
{
    public class WalletCntr
    {
        private readonly PEcontext db;

        public WalletCntr()
        {
            db = new PEcontext();
        }

        public async Task Create(string name, Currency currency)
        {
            var wallet = new Wallet();
            await db.Wallets.AddAsync(wallet);
            var walletType = new WalletType(name, wallet, currency);
            await db.WalletTypes.AddAsync(walletType);
            await db.SaveChangesAsync();
        }

        public async Task<List<Wallet>> ReadAll()
        {
            return await db.Wallets.Include(w => w.WalletType).ToListAsync();
        }

        public async Task<Wallet> Read(int id)
        {
            return await db.Wallets.Include(w => w.WalletType)
                                   .Include(c => c.CategoryOperations)
                                   .ThenInclude(c => c.Category)
                                   .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Update(int id, string name, Currency currency)
        {
            var walletType = await db.WalletTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (walletType != null)
            {
                walletType.Name = name;
                walletType.Currency = currency;
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var wallet = await db.Wallets.FirstOrDefaultAsync(x => x.Id == id);

            if (wallet != null)
            {
                db.Wallets.Remove(wallet);
                await db.SaveChangesAsync();
            }
        }

        public async Task TransferMoney(decimal sum, int fromId, int toId)
        {
            var fWallet = await db.Wallets.FirstOrDefaultAsync(w => w.Id == fromId);
            var tWallet = await db.Wallets.FirstOrDefaultAsync(w => w.Id == toId);

            if (fWallet != null && tWallet != null)
            {
                fWallet.Balance -= sum;
                tWallet.Balance += sum;
                await db.SaveChangesAsync();
            }
        }
    }
}

