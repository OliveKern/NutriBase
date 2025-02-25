using Microsoft.EntityFrameworkCore;
using NutriBase.Logic.Entities.App;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriBase.Logic.Entities.Account;

[Table("Users", Schema = "Account")]
[Index(nameof(Username), IsUnique = true)]
public class User : VersionEntity
{
    public string Username { get; set; } = string.Empty;

    public string Firstname { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    public string EMail { get; set; } = string.Empty;

    public byte[] PasswordHash { get; set; } = new byte[0];

    public byte[] PasswordSalt { get; set; } = new byte[0];
}
