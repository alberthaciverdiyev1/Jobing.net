namespace Services.Companies;

public record CompanyUserDto(
    int Id,
    string Name,
    string Description,
    string? Logo
);