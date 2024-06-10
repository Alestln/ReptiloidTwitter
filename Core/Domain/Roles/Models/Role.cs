namespace Core.Domain.Roles.Models;

public class Role
{
    public Guid Id { get; private set; }

    public string Title { get; private set; }

    private Role(Guid id, string title)
    {
        Id = id;
        Title = title;
    }
    
    public void Update(string title)
    {
        Title = title;
    }
}