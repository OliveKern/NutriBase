using NutriBase.Logic.Controllers.Base;
using NutriBase.Logic.Entities.Base;
using NutriBase.Logic.Models.Base;
using System.Reflection;

namespace NutriBase.Logic.Services.Base
{
    public class GroceryService : ServiceObject
    {
        private GroceriesController groceriesCtrl = new();

        public async Task<GroceryDto> InsertGroceryAsync(GroceryDto groceryDto)
        {
            var grocery = new Grocery
            {
                Definition = groceryDto.Definition,
                Description = groceryDto.Description,
                Price = groceryDto.Price,
                PackageSize = groceryDto.PackageSize,
                KaloriesPer100Gram = groceryDto.KaloriesPer100Gram,
                ProteinPer100Gram = groceryDto.ProteinPer100Gram,
                SugarPer100Gram = groceryDto.SugarPer100Gram,
                NutritionForm = groceryDto.NutritionForm
            };

            await groceriesCtrl.InsertAsync(grocery);
            await groceriesCtrl.SaveChangesAsync();

            return groceryDto;
        }

        public async Task<GroceryDto?> RemoveGroceryAsync(int id)
        {
            var returnEnt = await groceriesCtrl.DeleteAsync(id);
            await groceriesCtrl.SaveChangesAsync();

            return returnEnt == null ? null : new GroceryDto 
            {
                Id = returnEnt.Id,
                Definition = returnEnt.Definition,
                Description = returnEnt.Description,
                Price = returnEnt.Price,
                PackageSize = returnEnt.PackageSize,
                KaloriesPer100Gram = returnEnt.KaloriesPer100Gram,
                ProteinPer100Gram = returnEnt.ProteinPer100Gram,
                SugarPer100Gram = returnEnt.SugarPer100Gram,
                NutritionForm = returnEnt.NutritionForm
            };
        }
    }
}
