using System.ComponentModel.DataAnnotations;
using NutriBase.Logic.Contracts;

namespace NutriBase.Logic.Entities;

public abstract class IdentityEntity : IIdentifyable
{
    [Key]       //EF would recognize Id as primary key even without [Key] tag.
    public int Id {get; internal set;}
}
