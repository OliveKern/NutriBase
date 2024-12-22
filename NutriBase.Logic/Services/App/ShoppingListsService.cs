using NutriBase.Logic.Controllers.App;
using NutriBase.Logic.Controllers.Base;
using NutriBase.Logic.Entities.App;
using NutriBase.Logic.Entities.Base;
using NutriBase.Logic.Models.App;

namespace NutriBase.Logic.Services.App;

public class ShoppingListsService : ServiceObject
{
    private ShoppingListsController shoListCtrl = new();

    public async Task<ShoppingListDto> InsertShoListAsync(ShoppingListDto shoListDto, List<Product> products)
    {
        if (products == null || products.Count == 0)
        {
            throw new ArgumentNullException($"{nameof(products)} are empty");
        }

        var shoList = new ShoppingList
        {
            Definition = shoListDto.Definition,
            TotalCost = CalculateTotalCost(products),
            Usage = shoListDto.Usage,
            DueDate = shoListDto.DueDate,
            GoodsNumber = products.Count(),
            CostNotAccurate = CheckPrices(products)
        };

        shoList.Groceries.AddRange(products.OfType<Grocery>());
        shoList.HouseholdItems.AddRange(products.OfType<HouseholdItem>());
        shoList = await shoListCtrl.InsertAsync(shoList);

        using var groceriesCtrl = new GroceriesController(shoListCtrl);
        using var houseHoItCtrl = new HouseholdItemsController(shoListCtrl);
        await groceriesCtrl.InsertNewGroceriesAsync(products.OfType<Grocery>().ToList());
        await houseHoItCtrl.InsertNewHouseholdItemsAsync(products.OfType<HouseholdItem>().ToList());

        return new ShoppingListDto 
        {
            Id = shoList.Id,
            Definition = shoList.Definition,
            TotalCost = shoList.TotalCost,
            Usage = shoList.Usage,
            DueDate = shoList.DueDate,
            GoodsNumber = shoList.GoodsNumber,
            CostNotAccurate = shoList.CostNotAccurate
        };
    }

    private decimal CalculateTotalCost(List<Product> products)
    {
        return products.Sum(p => p.Price ?? 0);
    }

    private bool CheckPrices(List<Product> products)
    {
        return products.Any(p => p.Price == null);
    }
}
