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

    public decimal TotalCost => Groceries.Sum(x => x.Price ?? 0) + HouseholdItems.Sum(x => x.Price ?? 0);
    public bool CostNotAccurate => Groceries.Any(x => x.Price == null) || HouseholdItems.Any(x => x.Price == null);
    public DateTime CreationDate = DateTime.UtcNow;

    //NavProps
    public List<Grocery> Groceries { get; set; } = new();
    public List<HouseholdItem> HouseholdItems { get; set; } = new();
    public User? User { get; set; }
}
