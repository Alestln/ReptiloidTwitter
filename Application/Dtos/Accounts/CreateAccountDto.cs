﻿namespace Application.Dtos.Accounts;

public class CreateAccountDto
{
    public string Username { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }
}