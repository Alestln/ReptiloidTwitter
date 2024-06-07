using Core.Common;
using Core.Domain.Accounts.Data;
using Core.Domain.Roles.Models;

namespace Core.Domain.Accounts.Models;

public class Account : Entity
{
    private readonly List<Role> _roles = new List<Role>(); 
    
    public Guid Id { get; private set; }

    public string Username { get; private set; }
    
    public string Password { get; private set; }

    public string Email { get; private set; }

    public DateTime RegistrationDate  { get; private set; }
    
    public IReadOnlyCollection<Role> Roles => _roles;

    private Account(Guid id, string username, string password, string email, DateTime registrationDate)
    {
        Id = id;
        Username = username;
        Password = password;
        Email = email;
        RegistrationDate = registrationDate;
    }

    public static Account Create(CreateAccountData data)
    {
        return new Account(
            id: Guid.NewGuid(),
            username: data.Username,
            password: data.Password,
            email: data.Email,
            registrationDate: DateTime.UtcNow);
    }
}