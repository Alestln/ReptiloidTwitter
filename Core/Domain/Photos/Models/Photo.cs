using Core.Common;

namespace Core.Domain.Photos.Models;

public class Photo : Entity
{
    public Guid Id { get; private set; }
    
    public string File { get; private set; }
    
    public DateTime UploadDate { get; private set; }

    private Photo(Guid id, string file, DateTime uploadDate)
    {
        Id = id;
        File = file;
        UploadDate = uploadDate;
    }

    public static Photo Create(string file)
    {
        return new Photo(
            id: Guid.NewGuid(),
            file: file,
            uploadDate: DateTime.UtcNow);
    }
}