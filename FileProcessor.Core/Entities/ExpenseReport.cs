namespace FileProcessor.Core.Entities;

public class ExpenseReport : BaseEntity
{
    public int OwnerId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int FileDataId { get; set; }

    public int ExpenseReportId { get; set; }

    public virtual FileInfo FileInfo { get; set; }
}