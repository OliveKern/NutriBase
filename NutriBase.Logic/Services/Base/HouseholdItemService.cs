using NutriBase.Logic.Controllers.Base;
using NutriBase.Logic.Entities.Base;
using NutriBase.Logic.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriBase.Logic.Services.Base
{
    public class HouseholdItemService : ServiceObject
    {
        private HouseholdItemsController houseHoldItemCtrl = new();

        public async Task<HouseholdItemDto> InsertHouseHoldItemAsync(HouseholdItemDto hhiDto)
        {
            var houseHoldItem = new HouseholdItem
            {
                Definition = hhiDto.Definition,
                Description = hhiDto.Description,
                Price = hhiDto.Price,
                PackageSize = hhiDto.PackageSize,
                Material = hhiDto.Material
            };

            await houseHoldItemCtrl.InsertAsync(houseHoldItem);
            await houseHoldItemCtrl.SaveChangesAsync();

            return hhiDto;
        }

        public async Task<HouseholdItemDto?> RemoveHouseHoldItemAsync(int id)
        {
            var returnEnt = await houseHoldItemCtrl.DeleteAsync(id);
            await houseHoldItemCtrl.SaveChangesAsync();

            return returnEnt == null ? null : new HouseholdItemDto
            {
                Definition = returnEnt.Definition,
                Description = returnEnt.Description,
                Price = returnEnt.Price,
                PackageSize = returnEnt.PackageSize,
                Material = returnEnt.Material
            };
        }
    }
}
