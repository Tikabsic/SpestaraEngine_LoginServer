using DatabaseIntegration.Database;
using DatabaseIntegration.Entities.Player;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Utils.Hasher;

namespace Services.Account
{
    internal class LoginService : ILoginService
    {
        private readonly AppDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;

        public LoginService(AppDbContext context,
            IPasswordHasher hasher)
        {
            _dbContext = context;
            _passwordHasher = hasher;
        }

        public async Task<bool> LoginToServer(LoginRequestDTO dto)
        {
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.AccountName == dto.AccountName);

            if (account == null)
            {
                throw new Exception("Account not found");
            }

            var passwordResult = _passwordHasher.Verify(account.Password, dto.Password);

            if (!passwordResult)
            {
                throw new Exception("Wrong Password");
            }
            return true;

        }

        public async Task<GameCharactersList> SendGameCharactersList(string accountName)
        {
            var account = await _dbContext.Accounts.Include(a => a.GameCharacters).FirstAsync(a => a.AccountName == accountName);
            var gameCharactersList = new GameCharactersList();

            if (account.GameCharacters != null && account.GameCharacters.Count > 0)
            {
                foreach (var character in account.GameCharacters)
                {
                    gameCharactersList._characters.Add(character);
                }
            }

            return gameCharactersList;

        }
    }
}
