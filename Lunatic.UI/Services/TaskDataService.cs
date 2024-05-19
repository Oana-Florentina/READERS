using Lunatic.UI.Contracts;
using Lunatic.UI.Models.Dtos;
using Lunatic.UI.Models.ViewModels;
using Lunatic.UI.Services.Responses;
using System.Net.Http.Json;

namespace Lunatic.UI.Services {
	public class TaskDataService : ITaskDataService {
		private const string RequestUri = "api/v1/tasks";
		private readonly HttpClient httpClient;
		private readonly ITokenService tokenService;

		public TaskDataService(HttpClient httpClient, ITokenService tokenService) {
			this.httpClient = httpClient;
			this.tokenService = tokenService;
		}

		public async Task<ApiResponse> AddTaskSectionAsync(Guid taskId, string taskSection) {
			var result = await httpClient.PostAsJsonAsync($"{RequestUri}/{taskId}/sections", taskSection); //TODO: FIX REQUEST VERB?!
			var response = await result.Content.ReadFromJsonAsync<ApiResponse>();
			response!.Success = result.IsSuccessStatusCode;
			return response!;
		}

		public async Task<ApiResponse<TaskDto>> CreateTaskAsync(CreateTaskDto taskViewModel) {
			var result = await httpClient.PostAsJsonAsync($"api/v1/projects/{taskViewModel.ProjectId}/tasks", taskViewModel);
			var response = await result.Content.ReadFromJsonAsync<ApiResponse<TaskDto>>();
			response!.Success = result.IsSuccessStatusCode;
			return response!;
		}

		public async Task<ApiResponse> DeleteTaskAsync(Guid projectId, Guid taskId) {
			var result = await httpClient.DeleteAsync($"api/v1/projects/{projectId}/tasks/{taskId}");
			var response = await result.Content.ReadFromJsonAsync<ApiResponse>();
			response!.Success = result.IsSuccessStatusCode;
			return response!;
		}

		public async Task<ApiResponse<TaskDto>> EditTaskInfoAsync(Guid taskId, EditTaskViewModel task) {
			var result = await httpClient.PutAsJsonAsync($"api/v1/projects/tasks/{taskId}", task);
			var response = await result.Content.ReadFromJsonAsync<ApiResponse<TaskDto>>();
			response!.Success = result.IsSuccessStatusCode;
			return response!;
		}

		public async Task<ApiResponse<TaskDto>> GetTaskByIdAsync(Guid taskId) {
			var result = await httpClient.GetAsync($"api/v1/projects/tasks/{taskId}");
			var response = await result.Content.ReadFromJsonAsync<ApiResponse<TaskDto>>();
			response!.Success = result.IsSuccessStatusCode;
			return response!;
		}

		public async Task<ApiResponse<decimal>> GetTaskPredictedDurationAsync(Guid taskId) {
			var result = await httpClient.GetAsync($"api/v1/projects/tasks/{taskId}/prediction");
			var response = await result.Content.ReadFromJsonAsync<ApiResponse<decimal>>();
			response!.Success = result.IsSuccessStatusCode;
			return response!;

		}

		public async Task<ApiResponse> UpdateTaskSectionAsync(Guid taskId, string taskSection) {
			var result = await httpClient.PutAsJsonAsync($"api/v1/projects/tasks/{taskId}/section",
				new { TaskId = taskId, Section = taskSection });
			var response = await result.Content.ReadFromJsonAsync<ApiResponse>();
			response!.Success = result.IsSuccessStatusCode;
			return response!;
		}

		public async Task<ApiResponse> UpdateTaskStatusAsync(Guid taskId, Models.Shared.TaskStatus taskStatus) {
			var result = await httpClient.PutAsJsonAsync($"api/v1/projects/tasks/{taskId}/status",
				new { taskId = taskId, status = taskStatus });
			var response = await result.Content.ReadFromJsonAsync<ApiResponse>();
			response!.Success = result.IsSuccessStatusCode;
			return response!;
		}
	}
}
