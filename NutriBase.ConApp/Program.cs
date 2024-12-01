using Bogus;
using NutriBase.Logic.Controllers.Accounts;
using NutriBase.Logic.Entities.Account;
using NutriBase.Logic.Modules.Extensions;

namespace NutriBase.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TestingConApp");

            ControllerTests();
            ExtensionMethodTests();

        }

        private static void ControllerTests()
        {
            throw new NotImplementedException();
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
