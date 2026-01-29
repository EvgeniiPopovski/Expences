using System.Reflection;
using Expenses.ApplicationCore.Entities;
using Expenses.ApplicationCore.Interfaces;
using Expenses.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Expenses.Infrastructure.Database;

public class ApplicationDbContext
    : IdentityDbContext<IdentityApplicationUser, IdentityRole<int>, int>,
        IApplicationDbContext
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

    public DbSet<AppUser> AppUsers => Set<AppUser>();

    public DbSet<Expense> Expenses => Set<Expense>();
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}