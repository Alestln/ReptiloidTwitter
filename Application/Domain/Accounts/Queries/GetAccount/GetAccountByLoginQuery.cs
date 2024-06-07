using Application.Dtos.Authentication;
using Core.Domain.Accounts.Models;
using MediatR;

namespace Application.Domain.Accounts.Queries.GetAccount;

public record GetAccountByLoginQuery(
    string Login,
    string Password) : IRequest<Account>;