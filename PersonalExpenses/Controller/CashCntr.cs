using Microsoft.EntityFrameworkCore;
using PersonalExpenses.Models;

namespace PersonalExpenses.Controller
{
    public class CashCntr
    {
        private readonly PEcontext db;

        public CashCntr()
        {
            db = new PEcontext();
        }

        public async Task AddIncome(decimal sum, int incomeId)
        {
            var income = await db.Incomes.FirstOrDefaultAsync(i => i.Id == incomeId);
            var cash = await db.Cash.FirstOrDefaultAsync();

            if (cash != null && income != null)
            {
                cash.Balance += sum;
                income.IncomesInfo.Add(new IncomeInfo(sum));
                await db.SaveChangesAsync();
            }
            if(cash == null && income != null)
            {
                cash = new Cash();
                cash.Balance += sum;
                await db.AddAsync(cash);
                income.IncomesInfo.Add(new IncomeInfo(sum));
                await db.SaveChangesAsync();
            }
        }

        public async Task AddExpense(decimal sum, int expId)
        {
            var cash = await db.Cash.FirstOrDefaultAsync();
            var expense = await db.Expenses.FirstOrDefaultAsync(e => e.Id == expId);

            if (cash != null && expense != null)
            {
                cash.Balance -= sum;
                expense.ExpensesInfo.Add(new ExpensesInfo(sum));
                await db.SaveChangesAsync();
            }

        }
    }
}
