using Lunatic.UI.Contracts;
using Lunatic.UI.ViewModels;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;
using Lunatic.UI.Services.Responses.Reader;

namespace Lunatic.UI.Services
{
    public class ReaderDataService : IReaderDataService
    {
        private const string RequestUri = "api/v1/reader";
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public ReaderDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }
        public async Task<AddReaderResponse> AddReaderAsync(ReaderViewModel readerViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            Console.WriteLine(readerViewModel.RatingId);

            var result = await httpClient.PostAsJsonAsync(RequestUri, readerViewModel);
            var content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            result.EnsureSuccessStatusCode();

            var contentx = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            var response = JsonSerializer.Deserialize<AddReaderResponse>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return response!;
        }


        public async Task<GetReaderByBookIdAndUserIdResponse> GetReaderByBookIdAndUserIdAsync(Guid bookId, Guid userId)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            
            var response = await httpClient.GetAsync($"{RequestUri}/bybookanduser?bookId={bookId}&userId={userId}");

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            var reader = JsonSerializer.Deserialize<GetReaderByBookIdAndUserIdResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return reader!;
        }

        public async Task<List<ReaderViewModel>> GetReadersByUserIdAsync(Guid userId)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            var response = await httpClient.GetAsync($"{RequestUri}/byUser/{userId}");

            var content = await response.Content.ReadAsStringAsync();
            var readers = JsonSerializer.Deserialize<List<ReaderViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return readers!;
        }


    }
}
