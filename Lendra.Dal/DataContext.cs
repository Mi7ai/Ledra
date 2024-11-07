using Ledra.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ledra.Dal
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
    }
}
