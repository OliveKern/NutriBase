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
using Microsoft.EntityFrameworkCore;
using NutriBase.Logic.DataContext;
using NutriBase.Logic.Services.Base;

namespace NutriBase.ConApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("TestingConApp");

            //ExtensionMethodTests();
            //await ControllerTests();
            //await InsertShoppingListTest();
            await InsertDummyGroceries();
            //await InsertDummyHouseholdItems();
            //await InsertDummyShoppinLists();
            //await InsertDummyRecipes();
        }

        private async static Task InsertDummyGroceries()
        {
            var groceries = new List<Grocery>();
            groceries.Add(new Grocery
            {
                Definition = "Milch",
                Price = 1.99m,
                PackageSize = "1L",
                KaloriesPer100Gram = 42,
                ProteinPer100Gram = 3.4,
                SugarPer100Gram = 5,
                NutritionForm = Logic.Modules.Enumerations.NutritionForm.Vegetarian
            });
            groceries.Add(new Grocery
            {
                Definition = "Eier",
                Price = 2.99m,
                PackageSize = "10 Stück",
                KaloriesPer100Gram = 155,
                ProteinPer100Gram = 13,
                SugarPer100Gram = 1.1,
                NutritionForm = Logic.Modules.Enumerations.NutritionForm.Vegetarian
            });
            groceries.Add(new Grocery
            {
                Definition = "Schwarzbrot",
                Description = "Brotprodukt",
                Price = 3.99m,
                PackageSize = "1kg",
                NutritionForm = Logic.Modules.Enumerations.NutritionForm.Vegan
            });
            //{
            //    "Milch",
            //    "Eier",
            //    "Schwarzbrot",
            //    "Butter",
            //    //"Käse",
            //    //"Wurst",
            //    //"Marmelade",
            //    //"Kaffee",
            //    //"Tee",
            //    //"Zucker",
            //};

            //var groceryFaker = new Faker<Grocery>()
            //    .RuleFor(g => g.Definition, f => f.PickRandom(groceriesDefs))
            //    .RuleFor(g => g.Description, f => f.Commerce.ProductDescription())
            //    .RuleFor(g => g.Price, f => f.Random.Decimal(1, 100))
            //    .RuleFor(g => g.PackageSize, f => f.Commerce.ProductMaterial())
            //    .RuleFor(g => g.KaloriesPer100Gram, f => f.Random.Int(1, 1000))
            //    .RuleFor(g => g.ProteinPer100Gram, f => f.Random.Int(1, 1000))
            //    .RuleFor(g => g.SugarPer100Gram, f => f.Random.Int(1, 1000))
            //    .RuleFor(g => g.NutritionForm, f => f.PickRandom<Logic.Modules.Enumerations.NutritionForm>());

            //var groceries = groceryFaker.Generate(10);

            var grocerySrv = new GroceryService();
            foreach (var grocery in groceries)
            {
                var dto = new GroceryDto();
                grocery.CopyProperties(dto);
                await grocerySrv.InsertGroceryAsync(dto);
            }
        }

        private async static void InsertDummyHouseholdItems()
        {
            throw new NotImplementedException();
        }

        private async static void InsertDummyShoppinLists()
        {
            throw new NotImplementedException();
        }

        private async static void InsertDummyRecipes()
        {
            throw new NotImplementedException();
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
