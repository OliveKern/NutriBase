using System.ComponentModel.DataAnnotations;
using NutriBase.Logic.Contracts;

namespace NutriBase.Logic.Models;

public class IdentityModel : IIdentifyable
{
    [Key]
    public int Id { get; internal set; }
}
