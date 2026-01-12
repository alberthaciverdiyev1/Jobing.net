namespace Repositories.Company;

public class Company : MultiLangEntityBase, IAuditEntity
{
    public int Id { get; set; }

    public string? Logo { get; set; }

    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
