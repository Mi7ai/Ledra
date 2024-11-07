using Ledra.Domain.Models;

namespace Ledra.Domain.Abstractions.Repositories
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetAllExpensesAsync();
        Task<Expense?> GetExpenseByIdAsync(int expenseId);
        Task<Expense> AddExpenseAsync(Expense expense);
        Task<Expense?> DeleteExpenseAsync(int expenseId);
        Task<Expense?> UpdateExpenseAsync(Expense expense);
    }
}
