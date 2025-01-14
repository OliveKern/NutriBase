using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriBase.Logic.Contracts;
using NutriBase.Logic.Models.Accounts;
using NutriBase.Logic.Services;

namespace NutriBase.WebApp.Controllers.Account
{
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            using var accountSrv = new AccountService();
            var users = await accountSrv.GetAllUsers();

            return users == null ? NotFound() : Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            using var accountSrv = new AccountService();
            var user = await accountSrv.GetUserById(id);

            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("register")]  //users/register
        public async Task<ActionResult<UserDto>> Register(UserDto user, ITokenService tokenService)
        {
            using var accountSrv = new AccountService();

            if (await accountSrv.UserExists(user.Username!)) return BadRequest("Username is already taken");

            var userDto = accountSrv.Register(user, tokenService);

            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserDto user, ITokenService tokenService)
        {
            using var accountSrv = new AccountService();

            var account = await accountSrv.Login(user, tokenService);
            if (account == null) return NotFound("Invalid username");

            var pwCorrect = accountSrv.CheckPassword(user.Password!, account.PasswordSalt!, account.PasswordHash!);
            if (pwCorrect == false) return NotFound("Invalid password");

            user.Username = account.Username;
            user.Password = null;
            user.PasswordSalt = null;
            user.PasswordHash = null;
            user.Token = tokenService.CreateToken(account);

            return Ok(user);
        }
    }
}
