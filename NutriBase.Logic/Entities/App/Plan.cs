using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using NutriBase.Logic.Entities.Account;
using NutriBase.Logic.Entities.Base;

namespace NutriBase.Logic.Entities.App;

[Index(nameof(Definition), IsUnique = true)]
public abstract class Plan : VersionEntity
{
    public int UserId { get; set; }

    [Required]
    [MaxLength(512)]
    public string Definition { get; set; } = string.Empty;

    public decimal TotalCost { get; set; }
    public bool CostNotAccurate { get; set; }
    public DateTime CreationDate = DateTime.UtcNow;

    //NavProps
    public List<Grocery> Groceries { get; set; } = new();
    public List<HouseholdItem> HouseholdItems { get; set; } = new();
    public User? User { get; set; }
}
