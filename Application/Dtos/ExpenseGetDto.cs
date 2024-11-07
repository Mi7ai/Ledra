using Ledra.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ledra.Application.Dtos
{
    public class ExpenseGetDto
    {
        public int ExpenseId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Category? Category { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
