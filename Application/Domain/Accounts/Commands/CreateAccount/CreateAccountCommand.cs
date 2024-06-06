using Application.Dtos.Accounts;
using MediatR;

namespace Application.Domain.Accounts.Commands.CreateAccount;

public record CreateAccountCommand(
    string Username,
    string Password,
    string Email) : IRequest<AuthenticationResponse>;