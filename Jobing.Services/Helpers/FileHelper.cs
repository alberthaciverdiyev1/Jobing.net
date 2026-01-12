using Microsoft.AspNetCore.Http;

namespace Services.Helpers;

public static class FileHelper
{
    public static async Task<string> SaveAsync(IFormFile? file, string folder)
    {
        if (file is null) return "File not found";

        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder);
        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadPath, fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Path.Combine(folder, fileName).Replace("\\", "/");
    }
}