using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NutriBase.Logic.Entities.Account;
using NutriBase.Logic.Entities.Base;

namespace NutriBase.Logic.Entities.App;

public abstract class Plan : VersionEntity
{
    public int UserId { get; set; }

    [Required]
    [MaxLength(512)]
    public string Definition { get; set; } = string.Empty;
    public decimal TotalCost { get; set; }
    public int IngredientNumber { get; set; }
    public DateTime CreationDate = DateTime.UtcNow;

    //NavProps
    public List<Product> Products { get; set; } = new();
    public User? User { get; set; }
}
