using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NutriBase.Logic.Entities.Account;
using NutriBase.Logic.Entities.Base;

namespace NutriBase.Logic.Entities.App;

public abstract class Plan : VersionEntity
{
    [MaxLength(512)]
    public string Definition { get; set; } = string.Empty;

    public decimal TotalCost { get; set; }

    public int IngredientNumber { get; set; }

    public DateTime CreationDate = DateTime.UtcNow;

    // NavProps
    public List<Grocery> Groceries { get; set; } = new List<Grocery>();

    public User? Writer { get; set; }
}
