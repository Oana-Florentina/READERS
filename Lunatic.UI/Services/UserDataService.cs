using Lunatic.UI.Contracts;
using Lunatic.UI.ViewModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Lunatic.UI.Services
{
    public class UserDataService : IUserDataService
    {
        private const string RequestUri = "api/v1/users"; 
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public UserDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            var token = await tokenService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await httpClient.GetAsync(RequestUri, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            // Read and deserialize the JSON response
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<UserViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return users ?? new List<UserViewModel>();
        }

        public async Task<UserViewModel?> GetUserByUsernameAsync(string username)
        {
            var token = await tokenService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await httpClient.GetAsync($"{RequestUri}/search?username={username}", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<UserViewModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return user;
        }
    }
}
