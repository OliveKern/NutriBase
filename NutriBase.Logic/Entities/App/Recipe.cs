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
    public string? Author { get; set; } = string.Empty;
    public int? DurationInMin { get; set; } 
    private int difficulty;
    public int Difficulty 
    { 
        get => difficulty;
        set
        {
            if(value<0 || value>6)
                throw new ArgumentOutOfRangeException(nameof(Difficulty), "Value must be between 1 and 6.");

            difficulty = value;
        } 
    }
    public NutritionForm? NutritionForm { get; set; }
}
