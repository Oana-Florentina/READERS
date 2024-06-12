using Lunatic.UI.Contracts;
using Lunatic.UI.Payload;
using Lunatic.UI.Services.Responses;
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

        public async Task<ProfileViewModel> GetUserByIdAsync(Guid userId)
        {
            var result = await httpClient.GetAsync($"{RequestUri}/{userId}");
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<GetUserByIdResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var profileViewModel = new ProfileViewModel
            {
                UserId = response.User.UserId,
                Username = response.User.Username,
                FirstName = response.User.FirstName,
                LastName = response.User.LastName,
                Email = response.User.Email,
                WantToReadIds = response.User.WantToReadIds,
            };
            return profileViewModel!;
        }
        public async Task<List<BookViewModel>> GetBooksIWantToReadByIdsAsync(Guid userId)
        {
            var token = await tokenService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Assume that the API accepts a list of GUIDs as a POST request to fetch book details by IDs
            var response = await httpClient.GetAsync($"{RequestUri}/{userId}/wanttoread");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<BookViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return books!;
        }
        public async Task<List<BookViewModel>> GetBooksIReadByIdsAsync(Guid userId)
        {
            var token = await tokenService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Assume that the API accepts a list of GUIDs as a POST request to fetch book details by IDs
            var response = await httpClient.GetAsync($"{RequestUri}/{userId}/readers");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<BookViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return books!;
        }

        public async Task<AddReaderResponse> AddReaderAsync(ReaderViewModel readerViewModel, Guid userId)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            Console.WriteLine(readerViewModel.RatingId);

            var result = await httpClient.PostAsJsonAsync($"api/v1/reader", readerViewModel);
            var content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            result.EnsureSuccessStatusCode();

            var contentx = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            var response = JsonSerializer.Deserialize<AddReaderResponse>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return response!;

        }





    }
}
