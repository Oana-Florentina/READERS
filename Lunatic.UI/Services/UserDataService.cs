﻿using Lunatic.UI.Contracts;
using Lunatic.UI.Payload;
using Lunatic.UI.Services.Responses;
using Lunatic.UI.Services.Responses.Favorites;
using Lunatic.UI.Services.Responses.FriendRequest;
using Lunatic.UI.Services.Responses.Reader;
using Lunatic.UI.Services.Responses.WantToRead;
using Lunatic.UI.ViewModels;
using System.Collections.Frozen;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Lunatic.UI.Services
{
    public class UserDataService : IUserDataService
    {
        private const string RequestUri = "api/v1/users"; 
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;
        private readonly IBookDataService bookDataService;

        public UserDataService(HttpClient httpClient, ITokenService tokenService, IBookDataService bookDataService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
            this.bookDataService = bookDataService;
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
                ReaderIds = response.User.ReaderIds,
                FavoriteIds = response.User.FavoriteIds,
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

            var response = await httpClient.GetAsync($"{RequestUri}/{userId}/wanttoread");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);

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
            Console.WriteLine(content);
            var books = JsonSerializer.Deserialize<List<BookViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return books!;
        }
        public async Task<AddReaderToUserResponse> AddReaderToUserAsync(Guid userId, Guid readerId)
        {
            try
            {
                // Set Authorization Header
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

                // Create the payload for the API request
                var command = new
                {
                    UserId = userId,
                    ReaderId = readerId
                };

                // Send the POST request
                var result = await httpClient.PostAsJsonAsync($"{RequestUri}/{userId}/readers", command);

                // Read the response content
                var content = await result.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {content}");

                // Check if the request was successful
                if (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error in AddReaderToUserAsync call.");
                    throw new ApplicationException($"API Error: {result.StatusCode} - {content}");
                }

                // Deserialize the response
                var response = JsonSerializer.Deserialize<AddReaderToUserResponse>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return response!;
            }
            catch (Exception ex)
            {
                // Log exception details
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }
        public async Task<AddWantToReadResponse> AddWantToReadAsync(Guid userId, Guid bookId)
        {
            try
            {
                // Set Authorization Header
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

                // Create the payload for the API request
                var command = new
                {
                    UserId = userId,
                    BookId = bookId
                };

                // Send the POST request
                var result = await httpClient.PostAsJsonAsync($"{RequestUri}/{userId}/wantToRead", command);

                // Read the response content
                var content = await result.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {content}");

                // Check if the request was successful
                if (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error in AddWantToReadAsync call.");
                    throw new ApplicationException($"API Error: {result.StatusCode} - {content}");
                }

                // Deserialize the response
                var response = JsonSerializer.Deserialize<AddWantToReadResponse>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return response!;
            }
            catch (Exception ex)
            {
                // Log exception details
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }
        public async Task<AddToFavoritesResponse> AddToFavoritesAsync(Guid userId, Guid bookId)
        {
            try
            {
                // Set Authorization Header
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

                // Create the payload for the API request
                var command = new
                {
                    UserId = userId,
                    BookId = bookId
                };

                // Send the POST request
                var result = await httpClient.PostAsJsonAsync($"{RequestUri}/{userId}/favorites", command);

                // Read the response content
                var content = await result.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {content}");

                // Check if the request was successful
                if (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error in AddToFavoritesAsync call.");
                    throw new ApplicationException($"API Error: {result.StatusCode} - {content}");
                }

                // Deserialize the response
                var response = JsonSerializer.Deserialize<AddToFavoritesResponse>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return response!;
            }
            catch (Exception ex)
            {
                // Log exception details
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }
        public async Task<List<BookViewModel>> GetFavsByUserIdAsync(Guid userId)
        {
            var token = await tokenService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Assume that the API accepts a list of GUIDs as a POST request to fetch book details by IDs
            var response = await httpClient.GetAsync($"{RequestUri}/{userId}/favorites");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<BookViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return books!;
        }
        public async Task<bool> IsBookFavorite(Guid userId, Guid bookId)
        {
            try
            {
                // Fetch all favorite books for the user
                var favoriteBooks = await GetFavsByUserIdAsync(userId);

                // Check if the specific bookId is in the list of favorites
                return favoriteBooks.Any(book => book.BookId == bookId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking favorite status: {ex.Message}");
                return false;  // In case of an error, assume not favorite for safety or handle accordingly
            }
        }
        public async Task<SendFriendRequestCommandResponse> SendFriendRequestAsync(Guid senderId, Guid receiverId)
        {
            try
            {
                // Set Authorization Header
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

                // Create the payload for the API request
                var command = new
                {
                    SenderId = senderId,
                    ReceiverId = receiverId
                };

                // Send the POST request
                var result = await httpClient.PostAsJsonAsync($"{RequestUri}/{senderId}/sendFriendRequest", command);

                // Read the response content
                var content = await result.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {content}");

                // Check if the request was successful
                if (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error in SendFriendRequestAsync call.");
                    throw new ApplicationException($"API Error: {result.StatusCode} - {content}");
                }

                // Deserialize the response
                var response = JsonSerializer.Deserialize<SendFriendRequestCommandResponse>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return response!;
            }
            catch (Exception ex)
            {
                // Log exception details
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }
        public async Task<List<FriendRequestViewModel>> GetFriendRequestsByUserIdAsync(Guid userId)
        {
            var token = await tokenService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Assume that the API accepts a list of GUIDs as a POST request to fetch book details by IDs
            var response = await httpClient.GetAsync($"{RequestUri}/{userId}/getfriendrequest");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var friendRequests = JsonSerializer.Deserialize<List<FriendRequestViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var filteredFriendRequests = friendRequests
                .Where(r => r.ReceiverId == userId)
                .ToList();

            return filteredFriendRequests!;
        }
        public async Task<Response> DeleteFriendRequestAsync(Guid requestId, bool status)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

            var result = await httpClient.DeleteAsync($"{RequestUri}/friendrequest/{requestId}?status={status}");
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<Response>();
            response!.Success = result.IsSuccessStatusCode;
            return response!;
        }
        public async Task<List<UserViewModel>> GetFriendsByUserIdAsync(Guid userId)
        {
            var token = await tokenService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await httpClient.GetAsync($"{RequestUri}/{userId}/friends");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var friends = JsonSerializer.Deserialize<List<UserViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return friends!;
        }
        public async Task<List<FriendRecommandationViewModel>> GetFriendRecommandationByUserIdAsync(Guid userId)
        {
            var token = await tokenService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Assume that the API accepts a list of GUIDs as a POST request to fetch book details by IDs
            var response = await httpClient.GetAsync($"api/v1/friendrecommandation/{userId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<GetFriendRecommandationByReceiverIdResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var friendRecommandations = result.FriendRecommandations
                .Where(r => r.ReceiverId == userId)
                .Select(r => new FriendRecommandationViewModel
                {
                    FriendRecommandationId = r.FriendRecommandationId,
                    SenderId = r.SenderId,
                    ReceiverId = r.ReceiverId,
                    BookId = r.BookId,
                }).ToList();

            return friendRecommandations!;
        }
        public async Task<SendFriendRecommandationResponse> SendFriendRecommandationAsync(FriendRecommandationViewModel recommandation)
        {
            var response = await httpClient.PostAsJsonAsync("api/v1/friendRecommandation", recommandation);
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<SendFriendRecommandationResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }
        public async Task<List<BookClubViewModel>> GetBookClubsByUserIdAsync(Guid userId)
        {
            var token = await tokenService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await httpClient.GetAsync($"{RequestUri}/{userId}/bookclubs");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var bookClubs = JsonSerializer.Deserialize<List<BookClubViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return bookClubs!;
        }
        public async Task<Response> AddBookClubToUserAsync(Guid userId, Guid bookClubId)
        {
            try
            {
                // Set Authorization Header
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());

                // Create the payload for the API request
                var command = new
                {
                    UserId = userId,
                    BookClubId = bookClubId
                };

                // Send the POST request
                var result = await httpClient.PostAsJsonAsync($"{RequestUri}/{userId}/bookClub", command);

                // Read the response content
                var content = await result.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {content}");

                // Check if the request was successful
                if (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error in AddBookClubToUserAsync call.");
                    throw new ApplicationException($"API Error: {result.StatusCode} - {content}");
                }
                
                // Deserialize the response
                var response = JsonSerializer.Deserialize<Response>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return response!;
            }
            catch (Exception ex)
            {
                // Log exception details
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }

        }
        public async Task<HttpResponseMessage> UpdateUserAsync(Guid userId, ProfileViewModel updatedUser)
        {
            var token = await tokenService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var userJson = JsonSerializer.Serialize(updatedUser);
            var content = new StringContent(userJson, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"{RequestUri}/{userId}", content);
            return response;
        }

        public async Task<List<BookViewModel>> RecommendBooksAsync(Guid userId)
        {
            // Fetch user data
            var user = await GetUserByIdAsync(userId);

            // Collect books from favorites, readers, and want-to-read lists
            var favoriteBooks = await GetFavsByUserIdAsync(userId);
            var readerBooks = await GetBooksIReadByIdsAsync(userId);
            var wantToReadBooks = await GetBooksIWantToReadByIdsAsync(userId);

            var allBooks = favoriteBooks.Concat(readerBooks).Concat(wantToReadBooks).ToList();

            // If no data is available, return 3 random books
            if (!allBooks.Any())
            {
                Console.WriteLine("No user data available for recommendations. Returning random books.");
                return await GetRandomBooksAsync(3);
            }

            // Create a recommendation pool based on genres, authors, and descriptions
            var recommendedBooks = new List<BookViewModel>();
            var genres = new HashSet<string>();
            var authors = new HashSet<string>();

            foreach (var book in allBooks)
            {
                genres.UnionWith(book.Genres.Split(',').Select(g => g.Trim()));
                authors.Add(book.Author);
            }

            // Fetch all books and filter by genres and authors
            var allAvailableBooks = await bookDataService.GetBooksAsync();
            foreach (var book in allAvailableBooks)
            {
                if (genres.Any(genre => book.Genres.Split(',').Select(g => g.Trim()).Contains(genre)) || authors.Contains(book.Author))
                {
                    recommendedBooks.Add(book);
                    Console.WriteLine($"Recommended book: {book.Title}");
                }
            }
            var rng = new Random();
            recommendedBooks = recommendedBooks.OrderBy(book => rng.Next()).ToList();

            // If not enough recommendations, fill with random books
            if (recommendedBooks.Count < 3)
            {
                Console.WriteLine("Not enough recommendations. Filling with random books.");
                var randomBooks = await GetRandomBooksAsync(3 - recommendedBooks.Count);
                recommendedBooks.AddRange(randomBooks);
            }
            
            // Return top 3 recommendations
            return recommendedBooks.Take(3).ToList();
        }


        private async Task<List<BookViewModel>> GetRandomBooksAsync(int count)
        {
            // Fetch all books
            var result = await httpClient.GetAsync($"api/v1/books");
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var allBooks = JsonSerializer.Deserialize<List<BookViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Select random books
            var randomBooks = allBooks.OrderBy(x => Guid.NewGuid()).Take(count).ToList();
            return randomBooks;
        }
       
    }
}
