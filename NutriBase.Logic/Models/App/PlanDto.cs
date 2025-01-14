using NutriBase.Logic.Models.Base;
using System;

namespace NutriBase.Logic.Models.App;

abstract public class PlanDto : VersionModel
{
    public int UserId { get; set; }
    public string Definition { get; set; } = string.Empty;

    public decimal? TotalCost { get; set; }
    public bool? CostNotAccurate { get; set; }
    public DateTime? CreationDate { get; set; }

    public List<ProductDto> Products { get; set; } = new();
}
