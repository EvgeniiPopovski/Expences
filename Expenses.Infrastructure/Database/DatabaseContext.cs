using System.Reflection;
using Expenses.ApplicationCore.Entities;
using Expenses.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Expenses.Infrastructure.Database;

public class ApplicationDbContext : IdentityDbContext<IdentityApplicationUser, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<AppUser> Users => Set<AppUser>();
    
    public DbSet<Expense> Expenses => Set<Expense>();
}