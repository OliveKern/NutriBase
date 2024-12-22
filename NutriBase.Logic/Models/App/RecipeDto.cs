using System;
using NutriBase.Logic.Modules.Enumerations;

namespace NutriBase.Logic.Models.App;

public class RecipeDto : PlanDto
{
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int? DurationInMin { get; set; }
    public int? Valuation { get; set; }
    public int Difficulty { get; set; }
    public NutritionForm? NutritionForm { get; set; }
    public int? IngredientNumber { get; set; }
}
