using System;
using System.ComponentModel.DataAnnotations.Schema;
using NutriBase.Logic.Modules.Enumerations;

namespace NutriBase.Logic.Entities.Base;

[Table("HouseholtItems", Schema = "Base")]
public class HouseholdItem : Product
{
    public Material? Material { get; set; }
}
