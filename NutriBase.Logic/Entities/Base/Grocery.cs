using System;
using System.ComponentModel.DataAnnotations.Schema;
using NutriBase.Logic.Entities.App;
using NutriBase.Logic.Modules.Enumerations;

namespace NutriBase.Logic.Entities.Base;

[Table("Groceries", Schema = "Base")]
public class Grocery: Product
{
    public double? KaloriesPer100Gram { get; set; }
    public double? ProteinPer100Gram { get; set; }
    public double? SugarPer100Gram { get; set; }
    public NutritionForm? NutritionForm { get; set; }
}
