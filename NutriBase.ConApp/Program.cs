using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriBase.Logic.Controllers.Accounts;
using NutriBase.Logic.Controllers.Base;
using NutriBase.Logic.Entities.Account;
using NutriBase.Logic.Entities.Base;
using NutriBase.Logic.Models.App;
using NutriBase.Logic.Models.Base;
using NutriBase.Logic.Modules.Extensions;
using NutriBase.Logic.Services;
using NutriBase.Logic.Services.App;
using Microsoft.Extensions.Configuration;
using NutriBase.Logic.Models.Accounts;

namespace NutriBase.ConApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("TestingConApp");


            //ExtensionMethodTests();
            //await ControllerTests();
            await InsertShoppingListTest();
        }

        private async static Task InsertShoppingListTest()
        {
            using ShoppingListsService shoLiSrv = new();

            var shoListDto = new ShoppingListDto
            {
                UserId = 13,
                Definition = "TestDef",
                Usage = "TestUsage",
                DueDate = DateTime.Now + TimeSpan.FromDays(7)
            };

            shoListDto.Products.Add(new GroceryDto
            {
                Definition = "TestDef",
                Description = "TestDisc",
                Price = 22.22m,
                PackageSize = "Fife tests in test package",
                KaloriesPer100Gram = 100,
                ProteinPer100Gram = 100,
                SugarPer100Gram = 100,
                NutritionForm = Logic.Modules.Enumerations.NutritionForm.Vegan
            });
            shoListDto.Products.Add(new HouseholdItemDto
            {
                Definition = "TestDef",
                Description = "TestDisc",
                Price = 22.22m,
                PackageSize = "Fife tests in test package",
                Material = Logic.Modules.Enumerations.Material.Glass
            });

            await shoLiSrv.InsertShoppingListAsync(shoListDto);
        }

        private static async Task ControllerTests()
        {
            using GroceriesController groceriesController = new();

            var grocery = new Grocery
            {
                Definition = "TestDef",
                Description = "TestDisc",
                Price = 22.22m,
                PackageSize = "Fife tests in test package",
                KaloriesPer100Gram = 100,
                ProteinPer100Gram = 100,
                SugarPer100Gram = 100,
                NutritionForm = Logic.Modules.Enumerations.NutritionForm.Vegan
            };

            Console.WriteLine($"{grocery.Definition}, " +
                $"{grocery.Description}, " +
                $"{grocery.Price}, {grocery.PackageSize}, " +
                $"{grocery.KaloriesPer100Gram}, " +
                $"{grocery.ProteinPer100Gram}, " +
                $"{grocery.SugarPer100Gram}," +
                $"{grocery.NutritionForm}"
                );
            Console.WriteLine("Press a key to insert the grocery");
            Console.ReadKey();

            Grocery testGrocery =  await groceriesController.InsertAsync(grocery);
            await groceriesController.SaveChangesAsync();

            Console.WriteLine($"{testGrocery.Definition}, " +
                $"{testGrocery.Description}, " +
                $"{testGrocery.Price}, {grocery.PackageSize}, " +
                $"{testGrocery.KaloriesPer100Gram}, " +
                $"{testGrocery.ProteinPer100Gram}, " +
                $"{testGrocery.SugarPer100Gram}," +
                $"{testGrocery.NutritionForm}"
                );
        }

        private static void ExtensionMethodTests()
        {

            var testString = new string("Hello test me now and get my wordcount!");
            int wordcount = testString.WordCount();

            Console.WriteLine($"Wordcount result: {wordcount}");
            Console.ReadKey();
        }
    }
}
