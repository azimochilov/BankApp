using BankWithMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankWithMvc.Data.AppDbContext;
public class BankDbContext : DbContext
{
    public BankDbContext(DbContextOptions<BankDbContext> options)
        : base(options)
    { }
    public DbSet<User> Users { get; set; }
}
