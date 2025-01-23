using AutoMapper;
using Ledra.Application.Dtos;
using Ledra.Domain.Abstractions.Repositories;
using Ledra.Domain.Abstractions.Services;
using Ledra.Domain.Models;

namespace Ledra.Services
{
    public class ExpenseService(IExpenseRepository expenseRepository, IMapper mapper) : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository = expenseRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Expense?> CreateExpenseAsync(ExpensePostPutDto expensePostPutDto)
        {
            var newExpense = _mapper.Map<Expense>(expensePostPutDto);
            newExpense.CreatedDate = DateTime.UtcNow;

            await _expenseRepository.AddExpenseAsync(newExpense);

            // check business logic
            if (newExpense == null)
            {
                return null;
            }

            return newExpense;
        }

        public async Task<Expense?> DeleteExpenseAsync(int id)
        {
            return await _expenseRepository.DeleteExpenseAsync(id);
        }

        public async Task<List<ExpenseGetDto>> GetAllExpensesAsync()
        {
            var expenses = await _expenseRepository.GetAllExpensesAsync();
            var expensesGetDto = _mapper.Map<List<ExpenseGetDto>>(expenses);
            return expensesGetDto;
        }

        public async Task<ExpenseGetDto?> GetExpenseByIdAsync(int id)
        {
            var expense = await _expenseRepository.GetExpenseByIdAsync(id);
            if (expense == null)
            {
                return null;
            }
            var expenseGetDto = _mapper.Map<ExpenseGetDto>(expense);
            return expenseGetDto;
        }

        public async Task<Expense?> UpdateExpenseAsync(ExpensePostPutDto expensePostPutDto, int expenseId)
        {
            var existingExpense = await _expenseRepository.GetExpenseByIdAsync(expenseId);
            // check business logic
            if (existingExpense == null)
                return null;

            _mapper.Map(expensePostPutDto, existingExpense);
            existingExpense.UpdatedDate = DateTime.UtcNow;

            await _expenseRepository.UpdateExpenseAsync(existingExpense);

            return existingExpense;
        }
    }
}
