using Blazored.LocalStorage;
using Lunatic.UI.Contracts;
using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace GloboTicket.TicketManagement.App.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;
        private readonly IDataService dataService;

        public AuthenticationService(HttpClient httpClient, ITokenService tokenService, IDataService dataService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
            this.dataService = dataService;
        }

        public async Task Login(LoginViewModel loginRequest)
        {
            var response = await httpClient.PostAsJsonAsync("api/v1/auth/login", loginRequest);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
           
            await tokenService.SetTokenAsync(loginResponse.Token);
            await dataService.SetItemAsync("UserId", loginResponse.UserId);
        }

        public async Task Logout()
        {
            await tokenService.RemoveTokenAsync();
            var result = await httpClient.PostAsync("api/v1/auth/logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task Register(RegisterViewModel registerRequest)
        {
            var result = await httpClient.PostAsJsonAsync("api/v1/auth/register", registerRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }
            result.EnsureSuccessStatusCode();
        }
        public async Task<Response> ResetPassword(string email)
        {
            var response = await httpClient.PostAsJsonAsync("/api/v1/auth/resetpassword", new { Email = email });
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var resetResponse = JsonSerializer.Deserialize<Response>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return resetResponse;
        }

        public async Task<Response> ConfirmPassword(string email, string newPassword)
        {
            var response = await httpClient.PostAsJsonAsync("/api/v1/auth/confirmpassword", new { Email = email, NewPassword = newPassword });
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var confirmResponse = JsonSerializer.Deserialize<Response>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return confirmResponse;
        }
    }
}
