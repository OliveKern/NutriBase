using System;

namespace NutriBase.Logic.Models.App;

public class ShoppingListDto : PlanDto
{
    public string Usage { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
}
