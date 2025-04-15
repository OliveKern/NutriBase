using NutriBase.Logic.Entities.App;

namespace NutriBase.Logic.Controllers.App;

public class ShoppingListsController : GenericController<ShoppingList>
{
    public override Task<ShoppingList> InsertAsync(ShoppingList shoLi)
    {
        shoLi.ModifiedDate = DateTime.UtcNow;
        return base.InsertAsync(shoLi);
    }
}
