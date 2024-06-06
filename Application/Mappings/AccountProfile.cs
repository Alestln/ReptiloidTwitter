using Application.Domain.Accounts.Commands.CreateAccount;
using Application.Dtos.Accounts;
using AutoMapper;
using Core.Domain.Accounts.Data;

namespace Application.Mappings;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<CreateAccountCommand, CreateAccountData>();

        CreateMap<CreateAccountDto, CreateAccountCommand>();
    }
}