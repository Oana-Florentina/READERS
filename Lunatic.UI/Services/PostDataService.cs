using Lunatic.UI.Contracts;
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
    public class PostDataService : IPostDataService
    {
        private const string RequestUri = "api/v1/posts";
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;
        private readonly IPostDataService postDataService;

        public PostDataService(HttpClient httpClient, ITokenService tokenService, IPostDataService postDataService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
            this.postDataService = postDataService;
        }
        public async Task<PostViewModel> GetPostByIdAsync(Guid postId)
        {
            var result = await httpClient.GetAsync($"{RequestUri}/{postId}");
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<CreatePostResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var postViewModel = new PostViewModel
            {
                PostId = response.Post.PostId,
                BookClubId = response.Post.BookClubId,
                UserId = response.Post.UserId,
                Text = response.Post.Text,
                CreatedDate = response.Post.CreatedDate,
            };
            return postViewModel!;
        }
    }
}
