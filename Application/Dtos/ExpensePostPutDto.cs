using Ledra.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ledra.Application.Dtos
{
    public class ExpensePostPutDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Category? Category { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
