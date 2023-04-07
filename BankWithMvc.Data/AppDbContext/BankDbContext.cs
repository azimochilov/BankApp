using BankWithMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankWithMvc.Data.AppDbContext;
public class BankDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=BankApp; Trusted_Connection=True;");
    }
    public DbSet<User> Users { get; set; }
}
