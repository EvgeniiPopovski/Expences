using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FileInfo = FileProcessor.Core.Entities.FileInfo;

namespace FileProcessor.Infrastructure.Configuration;

internal class FileInfoConfiguration : IEntityTypeConfiguration<FileInfo>
{
    public void Configure(EntityTypeBuilder<FileInfo> builder)
    {
        builder.HasKey(fi => fi.Id);

        builder.HasOne(fi => fi.Report)
            .WithOne(r => r.FileInfo)
            .HasForeignKey<FileInfo>()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(fi => fi.FileName)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(fi => fi.Type)
            .HasMaxLength(100)
            .IsRequired();
    }
}