namespace FileProcessor.Core.Entities;

public class FileInfo : BaseEntity
{
    public string Type { get; set; }

    public string FileName { get; set; }

    public virtual ExpenseReport Report { get; set; }
}