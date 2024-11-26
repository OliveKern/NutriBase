using System;
using System.ComponentModel.DataAnnotations.Schema;
using NutriBase.Logic.Modules.Enumerations;

namespace NutriBase.Logic.Entities.Base;

[Table("Groceries", Schema = "Base")]
public class Grocery : Product
{
    public int KaloriesPer100Gram { get; set; }
    public int ProteinPer100Gram { get; set; }
    public int SugarPer100Gram { get; set; }

    public NutritionForm? NutritionForm { get; set; }
}
