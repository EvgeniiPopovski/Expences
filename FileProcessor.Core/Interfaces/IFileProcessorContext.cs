using FileProcessor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using FileInfo = FileProcessor.Core.Entities.FileInfo;

namespace FileProcessor.Core.Interfaces;

public interface IFileProcessorContext
{
    public DbSet<Expense> Expenses { get; }

    public DbSet<ExpenseReport> ExpenseReports { get; }

    public DbSet<FileInfo> FileInfos { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}