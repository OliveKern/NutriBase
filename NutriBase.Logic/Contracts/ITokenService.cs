using NutriBase.Logic.Models.Accounts;

namespace NutriBase.Logic.Contracts;

public interface ITokenService
{
    string CreateToken(UserDto user);
}
