using System;
using System.ComponentModel.DataAnnotations.Schema;
using NutriBase.Logic.Modules.Enumerations;

namespace NutriBase.Logic.Entities.App;

[Table("Recipes", Schema = "App")]
public class Recipe : Plan
{
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int DurationInMin { get; set; }
    
    private int difficulty;
    public int Difficulty 
    { 
        get => difficulty;
        set
        {
            if(value<1 || value>6)
                throw new ArgumentOutOfRangeException(nameof(Difficulty), "Value must be between 1 and 6.");

            difficulty = value;
        } 
    }

    public NutritionForm? NutritionForm { get; set; }
}
