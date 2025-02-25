using System;

namespace NutriBase.Logic.Models.Accounts;

public class UserDto
{
    public string Username { get; set; } = string.Empty;

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? EMail { get; set; }

    public string? Password { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string? Token { get; set; }

    //eventually implement null sets for different usages.
}