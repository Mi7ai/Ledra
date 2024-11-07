using Ledra.Application.Dtos;
using Ledra.Domain.Models;

namespace Ledra.Domain.Abstractions.Services
{
    public interface IExpenseService
    {
        Task<List<ExpenseGetDto>> GetAllExpensesAsync();
        Task<ExpenseGetDto?> GetExpenseByIdAsync(int id);
        Task<Expense?> CreateExpenseAsync(ExpensePostPutDto expensePostPutDto);
        Task<Expense?> DeleteExpenseAsync(int id);
        Task<Expense?> UpdateExpenseAsync(ExpensePostPutDto expensePostPutDto, int expenseId);
    }
}
