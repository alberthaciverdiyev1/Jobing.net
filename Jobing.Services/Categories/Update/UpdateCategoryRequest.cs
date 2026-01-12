namespace Services.Categories.Update;

public record UpdateCategoryRequest(int Id, string NameAz, string NameRu, string NameEn, string NameTr, string Icon, bool IsActive);