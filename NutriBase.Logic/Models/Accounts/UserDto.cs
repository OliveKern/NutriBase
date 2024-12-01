using System;

namespace NutriBase.Logic.Models.Accounts;

public class UserDto
{
    public string? Username { get; set; }

    public string? Password { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string? Token { get; set; }

    //eventually implement null sets for different usages.
}