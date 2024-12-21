namespace NutriBase.Logic.Models.Base;

abstract public class ProductDto : VersionModel
{
    public string Definition { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public string? PackageSize { get; set; }
}
