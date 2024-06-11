using Blazored.LocalStorage;
using Lunatic.UI.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Specialized;

namespace Lunatic.UI.Services
{
    public class DataService: IDataService
    {
        private readonly ILocalStorageService localStorageService;

        public DataService(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        public async Task SetItemAsync(string key, string value)
        {
            await localStorageService.SetItemAsync(key, value);
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            var value = await localStorageService.GetItemAsync<T>(key);

            return value;
        }
    }
}
