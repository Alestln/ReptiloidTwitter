namespace Core.Domain.Roles.Models;

public class Role
{
    public int Id { get; private set; }

    public string Title { get; private set; }

    private Role(string title)
    {
        Title = title;
    }
    
    public static Role Create(string title)
    {
        return new Role(title: title);
    }

    public void Update(string title)
    {
        Title = title;
    }
}