using System;

namespace NutriBase.Logic.Entities.Base;

public abstract class Product : IdentityEntity
{
    public string Definition { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Amount { get; set; }
}
