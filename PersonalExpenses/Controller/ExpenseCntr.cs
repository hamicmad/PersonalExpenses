using PersonalExpenses.Models;

namespace PersonalExpenses.Controller
{
    public class ExpenseCntr
    {
        private readonly PEcontext db;

        public ExpenseCntr()
        {
            db = new PEcontext();
        }

        public async Task AddExpense(string name)
        {
            var expense = new Expense(name);
            await db.Expenses.AddAsync(expense);
            await db.SaveChangesAsync();
        }
    }
}
