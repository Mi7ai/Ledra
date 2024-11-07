using AutoMapper;
using Ledra.Application.Dtos;
using Ledra.Domain.Abstractions.Services;
using Ledra.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ledra.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController(IExpenseService expenseService, IMapper mapper) : Controller
    {
        private readonly IExpenseService _expenseService = expenseService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAllExpensesAsync()
        {
            var expensesGetDto = await _expenseService.GetAllExpensesAsync();
            
            return Ok(expensesGetDto);
        }

        [HttpGet("{expenseId}")]
        public async Task<IActionResult> GetExpenseById(int expenseId)
        {
            var expense = await _expenseService.GetExpenseByIdAsync(expenseId);
            if (expense == null)
                return NotFound($"Expense with id {expenseId} was not found.");

            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpenseAsync([FromBody] ExpensePostPutDto expenseDto)
        {
            var expense = await _expenseService.CreateExpenseAsync(expenseDto);

            if (expense == null)
            {
                return NotFound($"Expense cannot be created.");
            }

            var expenseGetDto = _mapper.Map<ExpenseGetDto>(expense);

            return CreatedAtAction(nameof(GetExpenseById), new { expenseId = expenseGetDto.ExpenseId }, expenseGetDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExpenseAsync([FromBody] ExpensePostPutDto expenseDto, int expenseId)
        {
            var expense = await _expenseService.UpdateExpenseAsync(expenseDto, expenseId);
            if (expense == null)
            {
                return NotFound($"Expense with id {expenseId} was not found.");
            }

            return NoContent();
        }


        [HttpDelete("{expenseId}")]
        public async Task<IActionResult> DeleteExpense(int expenseId)
        {
            var deletedExpense = await _expenseService.DeleteExpenseAsync(expenseId);
            if (deletedExpense == null)
                return NotFound($"Expense with id {expenseId} was not found.");

            return NoContent();
        }
    }
}
