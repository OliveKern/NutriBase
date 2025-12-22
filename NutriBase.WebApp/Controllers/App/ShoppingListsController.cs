using Microsoft.AspNetCore.Mvc;
using NutriBase.Logic.Entities.Base;
using NutriBase.Logic.Models.App;
using NutriBase.Logic.Services.App;

namespace NutriBase.WebApp.Controllers.App
{
    public class ShoppingListsController : BaseApiController
    {
        internal ShoppingListsService shopListSrv = new ShoppingListsService();

        [HttpPost("PostShoppingList")]
        public async Task<ActionResult<ShoppingListDto>> PostShoppingList(ShoppingListDto shoppingListDto)
        {
            var shoppingList = await shopListSrv.InsertShoppingListAsync(shoppingListDto);
            return Ok(shoppingList);
        }

        [HttpGet("GetShoppingLists")]
        public async Task<ActionResult<IEnumerable<ShoppingListDto>>> GetShoppingLists()
        {
            var shoppingLists = await shopListSrv.GetAllShoppingListsAsync();
            return Ok(shoppingLists);
        }

        //[HttpPatch("PatchShoppingList")]
        //public async Task<ActionResult<ShoppingListDto>> PatchShoppingList(ShoppingListDto shoppingListDto)
        //{
        //    return await new Task<ActionResult<ShoppingListDto>>();
        //}
    }
}
