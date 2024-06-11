using Blazored.LocalStorage;
using Lunatic.UI.Contracts;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatic.UI.Services
{
    public class TokenService : ITokenService
    {
        private const string TOKEN = "token";
        private readonly ILocalStorageService localStorageService;

        public TokenService(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        public async Task SetTokenAsync(string token)
        {
            await localStorageService.SetItemAsync(TOKEN, token);
        }

        public async Task<string> GetTokenAsync()
        {
            var token = await localStorageService.GetItemAsync<string>(TOKEN);

            if (string.IsNullOrEmpty(token))
            {
                throw new InvalidOperationException("Token not found in local storage.");
            }

            return token;
        }

        public async Task RemoveTokenAsync()
        {
            await localStorageService.RemoveItemAsync(TOKEN);
        }

    }
}
