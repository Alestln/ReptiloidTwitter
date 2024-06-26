﻿using Core.Domain.Accounts.Models;
using MediatR;

namespace Application.Domain.Accounts.Commands.CreateAccount;

public record CreateAccountCommand(
    string Username,
    string Password,
    string Email,
    string FirstName,
    string LastName): IRequest<Account>;