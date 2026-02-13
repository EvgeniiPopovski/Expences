using System.Reflection;
using FileProcessor.Core.Entities;
using FileProcessor.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using FileInfo = FileProcessor.Core.Entities.FileInfo;

namespace FileProcessor.Infrastructure.Database;

public class FileProcessorContext : DbContext, IFileProcessorContext
{
    public FileProcessorContext(DbContextOptions<FileProcessorContext> options) : base(options) { }

    public DbSet<Expense> Expenses => Set<Expense>();

    public DbSet<ExpenseReport> ExpenseReports => Set<ExpenseReport>();

    public DbSet<FileInfo> FileInfos =>  Set<FileInfo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}