using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Models;

namespace PersonalExpenses.Controller
{
    public class IncomeCntr
    {
        private readonly PEcontext db;

        public IncomeCntr()
        {
            db = new PEcontext();
        }

        public async Task AddIncome(string name)
        {
            var income = new Income(name);
            await db.Incomes.AddAsync(income);
            await db.SaveChangesAsync();
        }

        public async Task<Income> Read(int id)
        {
            return await db.Incomes.Include(i => i.IncomesInfo)
                                   .FirstOrDefaultAsync(i => i.Id == id);
        }
    }

    public class IncomesInfoCntr
    {
        private readonly PEcontext db;

        public IncomesInfoCntr()
        {
            db = new PEcontext();
        }
    }
}
