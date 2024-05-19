using Lunatic.UI.Contracts;
using Lunatic.UI.Models.Dtos;
using Lunatic.UI.Services.Responses;
using System.Net.Http.Json;

namespace Lunatic.UI.Services {
	public class CommentDataService : ICommentDataService {
		private const string RequestUri = "api/v1/tasks";
		private readonly HttpClient httpClient;
		private readonly ITokenService tokenService;

		public CommentDataService(HttpClient httpClient, ITokenService tokenService) {
			this.httpClient = httpClient;
			this.tokenService = tokenService;
		}

		public async Task<ApiResponse<CommentDto>> GetCommentByIdAsync(Guid commentId) {
			var result = await httpClient.GetAsync($"api/v1/tasks/comments/{commentId}");
			var response = await result.Content.ReadFromJsonAsync<ApiResponse<CommentDto>>();
			response!.Success = result.IsSuccessStatusCode;
			return response!;
		}
		public async Task<ApiResponse<CommentDto>> AddCommentAsync(Guid taskId, Guid userId, string comment) {
			var result = await httpClient.PostAsJsonAsync($"api/v1/tasks/{taskId}/comments", new { TaskId = taskId, UserId = userId, Content = comment });
			var response = await result.Content.ReadFromJsonAsync<ApiResponse<CommentDto>>();
			response!.Success = result.IsSuccessStatusCode;
			return response!;
		}

		public async Task<ApiResponse> UpdateCommentAsync(Guid commentId, string comment) {
			var result = await httpClient.PutAsJsonAsync($"api/v1/tasks/comments/{commentId}", new { CommentId = commentId, Content = comment });
			var response = await result.Content.ReadFromJsonAsync<ApiResponse>();
			response!.Success = result.IsSuccessStatusCode;
			return response!;
		}
		public async Task<ApiResponse> DeleteCommentAsync(Guid taskId, Guid commentId) {
			var result = await httpClient.DeleteAsync($"api/v1/tasks/{taskId}/comments/{commentId}");
			var response = await result.Content.ReadFromJsonAsync<ApiResponse>();
			response!.Success = result.IsSuccessStatusCode;
			return response!;
		}
	}
}
