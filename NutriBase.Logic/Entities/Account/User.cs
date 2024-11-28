using NutriBase.Logic.Entities.App;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriBase.Logic.Entities.Account;

[Table("Users", Schema = "Account")]
public class User : VersionEntity
{
    [Required]
    [MaxLength(128)]
    public string Username { get; set; } = string.Empty;

    [Required]
    public byte[] PasswordHash { get; set; } = new byte[0];

    [Required]
    public byte[] PasswordSalt { get; set; } = new byte[0];

    //NavProps
    public List<Plan> Plans { get; set; } = new();
}
