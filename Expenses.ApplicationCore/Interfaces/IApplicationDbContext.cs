using Expenses.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Expenses.ApplicationCore.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Expense> Expenses { get; }

    public DbSet<AppUser> AppUsers { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}