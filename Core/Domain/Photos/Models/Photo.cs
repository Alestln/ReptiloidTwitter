using Core.Common;

namespace Core.Domain.Photos.Models;

public class Photo : Entity
{
    public Guid Id { get; private set; }
    
    public string FilePath { get; private set; }
    
    public DateTime UploadDate { get; private set; }

    public Photo(Guid id, string filePath, DateTime uploadDate)
    {
        Id = id;
        FilePath = filePath;
        UploadDate = uploadDate;
    }

    public static Photo Create(string filePath)
    {
        return new Photo(
            id: Guid.NewGuid(),
            filePath: filePath,
            uploadDate: DateTime.UtcNow);
    }
}