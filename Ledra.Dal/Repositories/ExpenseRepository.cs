using Ledra.Domain.Abstractions.Repositories;
using Ledra.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ledra.Dal.Repositories
{
    public class ExpenseRepository(DataContext ctx) : IExpenseRepository
    {
        private readonly DataContext _ctx = ctx;

        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            _ctx.Expenses.Add(expense);
            await _ctx.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense?> DeleteExpenseAsync(int expenseId)
        {
            var expense = await _ctx.Expenses.FindAsync(expenseId);

            if (expense != null)
            {
                _ctx.Expenses.Remove(expense);
                await _ctx.SaveChangesAsync();
            }
            return expense;
        }

        public async Task<List<Expense>> GetAllExpensesAsync()
        {
            return await _ctx.Expenses.ToListAsync();

        }

        public async Task<Expense?> GetExpenseByIdAsync(int expenseId)
        {
            return await _ctx.Expenses.FindAsync(expenseId);
        }

        public async Task<Expense?> UpdateExpenseAsync(Expense expense)
        {
            _ctx.Expenses.Update(expense);
            await _ctx.SaveChangesAsync();
            return expense;
        }
    }
}
