using Microsoft.EntityFrameworkCore;
using NutriBase.Logic.Contracts;
using NutriBase.Logic.Controllers.Accounts;
using NutriBase.Logic.Entities.Account;
using NutriBase.Logic.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NutriBase.Logic.Services
{
    public class AccountService : ServiceObject
    {
        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            using var usersCtrl = new UsersController();
            var users = await usersCtrl.EntitySet.ToListAsync().ConfigureAwait(false);
            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var userDto = new UserDto 
                { 
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    PasswordSalt = user.PasswordSalt,
                };
                userDtos.Add(userDto);
            }

            return userDtos;
        }

        public async Task<UserDto?> GetUserById(int id)
        {
            using var usersCtrl = new UsersController();
            var user = await usersCtrl.EntitySet.FindAsync(id).ConfigureAwait(false);

            return user == null ? null : new UserDto
            {
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
            };
        }

        public async Task<UserDto> Register(UserDto userDto, ITokenService tokenService)
        {
            using var hmac = new HMACSHA512();
            using var usersCtrl = new UsersController();

            var user = new User
            {
                Username = userDto.Username!.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password!)),
                PasswordSalt = hmac.Key
            };

            await usersCtrl.InsertAsync(user);
            await usersCtrl.SaveChangesAsync();

            userDto.Token = tokenService.CreateToken(userDto);
            userDto.Password = null;

            return userDto;
        }

        public async Task<UserDto?> Login(UserDto userDto, ITokenService tokenService)
        {
            using var userCtrl = new UsersController();
            var user = await userCtrl.EntitySet.FirstOrDefaultAsync(u => u.Username == userDto.Username);

            if(user != null)
            {
                userDto.PasswordHash = user.PasswordHash;
                userDto.PasswordSalt = user.PasswordSalt;
                userDto.Password = null;

                return userDto;
            }

            return null;
        }

        public bool CheckPassword(string password, byte[] pwSalt, byte[] pwHash) 
        {
            var correct = true;

            using var hmac = new HMACSHA512(pwSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != pwHash[i])
                    correct = false;
            }

            return correct;
        }

        public async Task<bool> UserExists(string username)
        {
            using var userCtrl = new UsersController();
            return await userCtrl.EntitySet.AnyAsync(u => u.Username == username);
        }
    }
}
