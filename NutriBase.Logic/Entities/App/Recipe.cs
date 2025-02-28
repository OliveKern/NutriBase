using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NutriBase.Logic.Entities.Account;
using NutriBase.Logic.Entities.Base;
using NutriBase.Logic.Modules.Enumerations;

namespace NutriBase.Logic.Entities.App;

[Table("Recipes", Schema = "App")]
public class Recipe : Plan
{
    [Required]
    public string Description { get; set; } = string.Empty;
    [MaxLength(128)]
    public string Author { get; set; } = string.Empty;
    public int? DurationInMin { get; set; }
    public int? Valuation { get; set; }
    public int Difficulty { get; set; } 
    public NutritionForm? NutritionForm { get; set; }
}
