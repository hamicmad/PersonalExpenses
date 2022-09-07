using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Enums;
using PersonalExpenses.Models;

namespace PersonalExpenses.Controller
{
    public class CategoryCntr
    {
        private readonly PEcontext db;

        public CategoryCntr()
        {
            db = new PEcontext();
        }

        public async Task Create(string name, Types type)
        {
            var category = new Category(name, type);
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
        }

        public async Task<List<Category>> ReadAll()
        {
            return await db.Categories.Include(i => i.CategoryOperations).ToListAsync();
        }
        
        public async Task<Category> Read(int id)
        {
            return await db.Categories.Include(c => c.CategoryOperations)
                                      .ThenInclude(c => c.Wallet.WalletType)
                                      .FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task Update(int id, string name, Types type)
        {
            var category = await db.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                category.Name = name;
                category.Type = type;
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category != null)
            {
                db.Categories.Remove(category);
                await db.SaveChangesAsync();
            }
        }
    }
}

