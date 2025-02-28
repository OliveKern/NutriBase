using NutriBase.Logic.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriBase.Logic.Entities.App;

[Table("ShoppingLists", Schema = "App")]
public class ShoppingList : Plan
{
    [MaxLength(128)]
    public string Usage { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
}
