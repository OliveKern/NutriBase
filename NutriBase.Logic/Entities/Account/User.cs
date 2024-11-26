using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriBase.Logic.Entities.Account;

[Table("Users", Schema = "Account")]
public class User : IdentityEntity
{
    [MaxLength(1024)]
    public required string Username { get; set; }

    public required byte[] PasswordHash { get; set; }

    public required byte[] PasswordSalt { get; set; }

}
