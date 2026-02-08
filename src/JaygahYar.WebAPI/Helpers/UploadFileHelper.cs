using Microsoft.AspNetCore.Http;

namespace JaygahYar.WebAPI.Helpers;

public static class UploadFileHelper
{
    private const string UploadRootFolderName = "uploadDoc";

    public static async Task<string> SaveAsync(
        IFormFile file,
        string contentRootPath,
        string category,
        CancellationToken cancellationToken)
    {
        if (file == null) throw new ArgumentNullException(nameof(file));
        if (file.Length <= 0) throw new InvalidOperationException("File is empty.");

        var safeCategory = (category ?? "misc").Trim();
        if (string.IsNullOrWhiteSpace(safeCategory)) safeCategory = "misc";

        var uploadsRoot = Path.Combine(contentRootPath, UploadRootFolderName, safeCategory);
        Directory.CreateDirectory(uploadsRoot);

        var safeFileName = Path.GetFileName(file.FileName);
        var uniqueName = $"{Guid.NewGuid():N}_{safeFileName}";
        var absolutePath = Path.Combine(uploadsRoot, uniqueName);

        await using (var stream = new FileStream(absolutePath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
        {
            await file.CopyToAsync(stream, cancellationToken);
        }

        // store as relative path for DB portability
        return Path.Combine(UploadRootFolderName, safeCategory, uniqueName).Replace('\\', '/');
    }
}

