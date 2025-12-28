namespace Services.Cities.Create;

public record CreateCityResponse(int Id, string Name,bool IsActive,DateTime CreatedAt);