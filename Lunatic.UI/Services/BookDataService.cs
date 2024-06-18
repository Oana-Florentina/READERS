using Lunatic.UI.Contracts;
using Lunatic.UI.Payload;
using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Lunatic.UI.Services
{
    public class BookDataService : IBookDataService
    {
        private const string RequestUri = "api/v1/books";
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public BookDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task<ApiResponse<BookDto>> CreateBookAsync(BookViewModel bookViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PostAsJsonAsync(RequestUri, bookViewModel);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<BookDto>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }

        public async Task<List<BookViewModel>> GetBooksAsync()
        {
            var result = await httpClient.GetAsync(RequestUri, HttpCompletionOption.ResponseHeadersRead);
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            if (!result.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var books = JsonSerializer.Deserialize<List<BookViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return books!;
        }
        
        public async Task<BookViewModel> GetBookByIdAsync(Guid bookId)
        {
            var result = await httpClient.GetAsync($"{RequestUri}/{bookId}");
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var book = JsonSerializer.Deserialize<GetBookByIdResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var bookViewModel = new BookViewModel
            {
                BookId = book.Book.BookId,
                Title = book.Book.Title,
                Author = book.Book.Author,
                AverageScore = book.Book.AverageScore,
                Year = book.Book.Year,
                Cover = book.Book.Cover,
                Description = book.Book.Description,
                Ratings = book.Book.Ratings,
                Genres = book.Book.Genres,

            };
            
            return bookViewModel!;
        }

        public async Task<List<BookViewModel>> GetPopularBooksAsync()
        {
            try
            {
                var readersResponse = await httpClient.GetAsync("api/v1/reader");
                readersResponse.EnsureSuccessStatusCode();
                var readersJson = await readersResponse.Content.ReadAsStringAsync();

                var readers = JsonSerializer.Deserialize<List<ReaderViewModel>>(readersJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var popularBookIds = readers
                    .GroupBy(r => r.BookId)
                    .OrderByDescending(g => g.Count())
                    .Take(3)
                    .Select(g => g.Key)
                    .ToList();

                var allBooks = await GetBooksAsync();
                var popularBooks = allBooks
                    .Where(book => popularBookIds.Contains(book.BookId))
                    .ToList();

                foreach (var book in popularBooks)
                {
                    Console.WriteLine($"Popular book: {book.Title}");
                }

                return popularBooks!;
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine($"Error loading data: {httpRequestException.Message}");
                return new List<BookViewModel>();
            }
            catch (JsonException jsonException)
            {
                Console.WriteLine($"JSON error: {jsonException.Message}");
                return new List<BookViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return new List<BookViewModel>();
            }
        }



    }
}
