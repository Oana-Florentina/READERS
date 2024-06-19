using Lunatic.UI.Contracts;
using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;
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
        public async Task<bool> JoinBookClub(ProfileViewModel CurrentUser, Guid bookClubId)
        {
            if (CurrentUser != null)
            {
                Console.WriteLine($"User: {CurrentUser.UserId}");
                var updateUserPayload = new
                {
                    userId = CurrentUser.UserId,
                    firstName = CurrentUser.FirstName,
                    lastName = CurrentUser.LastName,
                    email = CurrentUser.Email,
                    bookClub = bookClubId
                };
                Console.WriteLine(updateUserPayload);
                var updateUserResponse = await httpClient.PutAsJsonAsync($"api/v1/users/{CurrentUser.UserId}", updateUserPayload);

                if (updateUserResponse.IsSuccessStatusCode)
                {
                    var bookClub = await GetBookClubByIdAsync(bookClubId);
                    Console.WriteLine(bookClub.Members);
                    if (bookClub != null)
                    {
                        bookClub.Members!.Add(CurrentUser.UserId);
                        
                          

                        var updateBookClubPayload = new
                        {
                            bookClub = bookClub.BookClubId,
                            title = bookClub.Title,
                            description = bookClub.Description,
                            books = bookClub.Books,
                            members = bookClub.Members
                        };

                        var updateBookClubResponse = await httpClient.PutAsJsonAsync($"api/v1/bookclub/{bookClubId}", updateBookClubPayload);

                        return updateBookClubResponse.IsSuccessStatusCode;
                    }
                }
            }

            return false;
        }





    }
}
