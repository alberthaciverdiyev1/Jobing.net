namespace Services.Cities;

public record CityDto(int Id, string Name,bool IsActive,DateTime CreatedAt);

// public class CityDto
// {
//     public int Id { get; init; }
//     public string Name { get; init; }
//     public bool IsActive { get; init; }
//     
//     public DateTime CreatedAt { get; init; }
// }