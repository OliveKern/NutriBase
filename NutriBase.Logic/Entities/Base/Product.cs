using Microsoft.EntityFrameworkCore;
using NutriBase.Logic.Entities.App;
using System;
using System.ComponentModel.DataAnnotations;

namespace NutriBase.Logic.Entities.Base;

[Index(nameof(Definition), IsUnique = true)]
public abstract class Product : VersionEntity
{
    [Required]
    [MaxLength(128)]
    public string Definition { get; set; } = string.Empty;
    [MaxLength(1024)]
    public string? Description { get; set; } = string.Empty;
    public decimal? Price { get; set; } = 0;
    [MaxLength(128)]
    public string? PackageSize { get; set; }
    
    //NavProps
    public List<Recipe> Recipes { get; set; } = new();
    public List<ShoppingList> ShoppingLists { get; set; } = new();    
}
