using Ledra.Application.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ledra.Domain.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Category? Category { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
