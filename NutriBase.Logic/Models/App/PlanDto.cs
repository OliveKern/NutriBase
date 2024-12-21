using System;

namespace NutriBase.Logic.Models.App;

abstract public class PlanDto : VersionModel
{
    public int UserId { get; set; }
    public string Definition { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
}
