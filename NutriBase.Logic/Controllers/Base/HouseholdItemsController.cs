using System;
using NutriBase.Logic.Entities.Base;

namespace NutriBase.Logic.Controllers.Base;

public class HouseholdItemsController : GenericController<HouseholdItem>
{
    public HouseholdItemsController()
    {
    }
    public HouseholdItemsController(ControllerObject other) : base(other)
    {
    }

    internal async Task<IEnumerable<HouseholdItem>> InsertNewHouseholdItemsAsync(List<HouseholdItem> householdItems)
    {
        List<HouseholdItem> dbSet = await GetAllAsync();
        List<HouseholdItem> newHHIs = new();

        newHHIs.AddRange(householdItems.Except(dbSet));

        return await InsertMultipleAsync(newHHIs);
    }
}
