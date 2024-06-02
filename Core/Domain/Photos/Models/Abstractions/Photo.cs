using Core.Common;
using Core.Domain.Photos.Enums;

namespace Core.Domain.Photos.Models.Abstractions;

public abstract class Photo : Entity
{
    public Guid Id { get; private set; }
    
    public string FilePath { get; private set; }
    
    public DateTime UploadDate { get; private set; }
    
    public PhotoType Type { get; private set; }
    
    protected Photo(Guid id, string filePath, DateTime uploadDate, PhotoType type)
    {
        Id = id;
        FilePath = filePath;
        UploadDate = uploadDate;
        Type = type;
    }
}