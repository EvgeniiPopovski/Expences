using FileProcessor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileProcessor.Infrastructure.Configuration;

internal class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.OwnerName)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(e => e.Comment)
            .IsRequired()
            .HasMaxLength(2000);
    }
}