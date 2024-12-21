using System;
using NutriBase.Logic.Modules.Enumerations;

namespace NutriBase.Logic.Models.Base;

public class HouseholdItemDto : ProductDto
{
    public Material? Material { get; set; }
}
