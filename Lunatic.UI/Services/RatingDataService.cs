using Lunatic.UI.Contracts;
using Lunatic.UI.Payload;
using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Lunatic.UI.Services
{
    public class RatingDataService : IRatingDataService
    {
        private const string RequestUri = "api/v1/rating";
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public RatingDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task<ApiResponse<RatingViewModel>> CreateRatingAsync(RatingViewModel ratingViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PostAsJsonAsync(RequestUri, ratingViewModel);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<RatingViewModel>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }

        public async Task<List<RatingViewModel>> GetRatingsAsync()
        {
            var result = await httpClient.GetAsync(RequestUri, HttpCompletionOption.ResponseHeadersRead);
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            if (!result.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var ratings = JsonSerializer.Deserialize<List<RatingViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return ratings!;
        }

        public async Task<RatingViewModel> GetRatingByIdAsync(Guid ratingId)
        {
            var result = await httpClient.GetAsync($"{RequestUri}/{ratingId}");
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var rating = JsonSerializer.Deserialize<RatingViewModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return rating!;
        }

        public async Task<ApiResponse<RatingViewModel>> UpdateRatingAsync(Guid ratingId, RatingViewModel ratingViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PutAsJsonAsync($"{RequestUri}/{ratingId}", ratingViewModel);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<RatingViewModel>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }

        public async Task<ApiResponse<RatingViewModel>> DeleteRatingAsync(Guid ratingId)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.DeleteAsync($"{RequestUri}/{ratingId}");
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<RatingViewModel>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }

        public async Task<AddRatingResponse> AddRatingAsync(RatingViewModel ratingViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            var result = await httpClient.PostAsJsonAsync(RequestUri, ratingViewModel);
            result.EnsureSuccessStatusCode();

            var content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            var response = JsonSerializer.Deserialize<AddRatingResponse>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return response!;
        }

        public async Task<List<RatingViewModel>> GetRatingsByBookIdAsync(Guid bookId)
        {
          
            var token = await tokenService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Assume that the API accepts a list of GUIDs as a POST request to fetch book details by IDs
            var response = await httpClient.GetAsync($"{RequestUri}/{bookId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }


           
            var result = JsonSerializer.Deserialize<GetRatingsByBookIdResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var ratings = result.Ratings
                .Where(r => r.BookId == bookId)
                .Select(r => new RatingViewModel
                {
                    RatingId = r.RatingId,
                    BookId = r.BookId,
                    UserId = r.UserId,
                    Score = r.Score,
                    CommentMessage = r.CommentMessage
                }).ToList();

            return ratings!;
        }
    }
}
