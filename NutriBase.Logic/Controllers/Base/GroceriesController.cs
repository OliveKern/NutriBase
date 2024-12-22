using System;
using NutriBase.Logic.Entities.Base;

namespace NutriBase.Logic.Controllers.Base;

public class GroceriesController : GenericController<Grocery>
{
    public GroceriesController(ControllerObject other) : base(other)
    {
    }

    internal async Task<IEnumerable<Grocery>> InsertNewGroceriesAsync(List<Grocery> groceries)
    {
        List<Grocery> dbSet = EntitySet.AsQueryable().ToList();
        List<Grocery> newGroceries = new();

        newGroceries.AddRange(groceries.Except(dbSet));

        return await InsertMultipleAsync(newGroceries);
    }
}
