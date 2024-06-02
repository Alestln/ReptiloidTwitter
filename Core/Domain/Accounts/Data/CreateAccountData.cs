namespace Core.Domain.Accounts.Data;

public record CreateAccountData(
    string Username, 
    string Password, 
    string Email);