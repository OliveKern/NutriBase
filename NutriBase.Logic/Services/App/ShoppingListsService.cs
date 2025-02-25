using NutriBase.Logic.Controllers.App;
using NutriBase.Logic.Controllers.Base;
using NutriBase.Logic.Entities.App;
using NutriBase.Logic.Entities.Base;
using NutriBase.Logic.Models.App;
using NutriBase.Logic.Models.Base;
using NutriBase.Logic.Modules.Extensions;

namespace NutriBase.Logic.Services.App;

public class ShoppingListsService : ServiceObject
{
    private ShoppingListsController shoListCtrl = new();

    public async Task<ShoppingListDto> InsertShoppingListAsync(ShoppingListDto shoListDto)
    {
        if (shoListDto.Products == null || shoListDto.Products.Count == 0)
        {
            throw new ArgumentNullException($"{nameof(shoListDto.Products)} are empty");
        }

        var shoList = ShoListDtoToEntity(shoListDto);

        foreach (var product in shoListDto.Products.OfType<GroceryDto>())
        {
            var prod = new Grocery();
            product.CopyProperties(prod);
            shoList.Groceries.Add(prod);
        }
        foreach (var product in shoListDto.Products.OfType<HouseholdItemDto>())
        {
            var prod = new HouseholdItem();
            product.CopyProperties(prod);
            shoList.HouseholdItems.Add(prod);
        }

        shoList = await shoListCtrl.InsertAsync(shoList);
        await shoListCtrl.SaveChangesAsync();

        shoList.CopyProperties(shoListDto);
        return shoListDto;
    }

    public async Task<IEnumerable<ShoppingListDto>> GetAllShoppingListsAsync()
    {
        var shoLists = await shoListCtrl.GetAllAsync();
        return shoLists.Select(shoList => new ShoppingListDto
        {
            Id = shoList.Id,
            Definition = shoList.Definition,
            TotalCost = shoList.TotalCost,
            Usage = shoList.Usage,
            DueDate = shoList.DueDate,
            GoodsNumber = shoList.GoodsNumber,
            CostNotAccurate = shoList.CostAccurate
        });
    }

    private ShoppingList ShoListDtoToEntity(ShoppingListDto shoListDto)
    {
        var shoList = new ShoppingList();
        shoListDto.CopyProperties(shoList);

        return shoList;
    }
}
