using System;
using NutriBase.Logic.Modules.Enumerations;

namespace NutriBase.Logic.Models.Base;

public class GroceryDto : ProductDto
{
    public double? KaloriesPer100Gram { get; set; }
    public double? ProteinPer100Gram { get; set; }
    public double? SugarPer100Gram { get; set; }
    public NutritionForm? NutritionForm { get; set; }
}
