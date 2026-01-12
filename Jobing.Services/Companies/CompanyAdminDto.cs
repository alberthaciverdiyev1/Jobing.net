namespace Services.Companies;

public record CompanyAdminDto(
    int Id,
    IDictionary<string, string> Name,
    IDictionary<string, string> Description,
    string? Logo,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);