using Lunatic.UI.Contracts;
using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;
using Lunatic.UI.Payload;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lunatic.UI.Services
{
    public class BookClubDataService : IBookClubDataService
    {
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public BookClubDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task<List<BookClubViewModel>> GetAllBookClubsAsync()
        {
            var token = await tokenService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await httpClient.GetAsync("api/v1/bookclub");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var bookClubs = JsonSerializer.Deserialize<List<BookClubViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return bookClubs!;
        }
        public async Task<BookClubViewModel> GetBookClubByIdAsync(Guid bookClubId)
        {
            var result = await httpClient.GetAsync($"api/v1/bookClub/{bookClubId}");
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var bookClub = JsonSerializer.Deserialize<GetBookClubByIdResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var bookClubViewModel = new BookClubViewModel
            {
                BookClubId = bookClub.BookClub.BookClubId,
                Title = bookClub.BookClub.Title,
                Description = bookClub.BookClub.Description,
                Books = bookClub.BookClub.Books,
                Members = bookClub.BookClub.Members
            };

            return bookClubViewModel!;
        }
        

        public async Task<BookClubDto> CreateBookClubAsync(BookClubViewModel bookClub)
        {
            var createBookClubResponse = await httpClient.PostAsJsonAsync("api/v1/bookclub", bookClub);
            createBookClubResponse.EnsureSuccessStatusCode();
            var content = await createBookClubResponse.Content.ReadAsStringAsync();
            var createdBookClub = JsonSerializer.Deserialize<CreateBookClubResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if(createdBookClub == null)
            {
                throw new ApplicationException("Cannot create book club");
            }
            return createdBookClub.BookClub!;
            
        }

        public async Task<ApiResponse<BookClubViewModel>> UpdateBookClubAsync(BookClubViewModel bookClub)
        {
            httpClient.DefaultRequestHeaders.Authorization
               = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PutAsJsonAsync($"api/v1/bookclub/{bookClub.BookClubId}", bookClub);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<BookClubViewModel>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }


    }
}
