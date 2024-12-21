using System;
using NutriBase.Logic.Modules.Enumerations;

namespace NutriBase.Logic.Models.Base;

public class GroceryDto : ProductDto
{
    public int? KaloriesPer100Gram { get; set; }
    public int? ProteinPer100Gram { get; set; }
    public int? SugarPer100Gram { get; set; }
    public NutritionForm? NutritionForm { get; set; }
}
