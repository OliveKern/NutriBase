using NutriBase.Logic.Controllers.Accounts;
using NutriBase.Logic.Entities.Account;

namespace NutriBase.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using UsersController usersCtrl = new UsersController();
            var entity = new User
            {
                Username = "Test Boy",
                PasswordHash = new byte[0],
                PasswordSalt = new byte[0]
            };
        }
    }
}
