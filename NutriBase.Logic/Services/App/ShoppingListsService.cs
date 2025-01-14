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

        var shoList = new ShoppingList
        {
            Definition = shoListDto.Definition,
            TotalCost = CalculateTotalCost(shoListDto.Products),
            Usage = shoListDto.Usage,
            DueDate = shoListDto.DueDate,
            GoodsNumber = shoListDto.Products.Count(),
            CostNotAccurate = CheckPrices(shoListDto.Products),
            UserId = shoListDto.UserId,
        };

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

    private decimal CalculateTotalCost(List<ProductDto> products)
    {
        return products.Sum(p => p.Price ?? 0);
    }
    private bool CheckPrices(List<ProductDto> products)
    {
        return products.Any(p => p.Price == null);
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
            CostNotAccurate = shoList.CostNotAccurate
        });
    }
}
