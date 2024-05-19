using Lunatic.UI.Models.Dtos;
using Lunatic.UI.Models.ViewModels;
using Lunatic.UI.Services.Responses;

namespace Lunatic.UI.Contracts {
	public interface ITaskDataService {
		Task<ApiResponse<TaskDto>> GetTaskByIdAsync(Guid taskId);
		Task<ApiResponse<TaskDto>> CreateTaskAsync(CreateTaskDto taskViewModel);
		Task<ApiResponse<TaskDto>> EditTaskInfoAsync(Guid taskId, EditTaskViewModel task);
		Task<ApiResponse> DeleteTaskAsync(Guid projectId, Guid taskId);
		Task<ApiResponse> UpdateTaskStatusAsync(Guid taskId, Models.Shared.TaskStatus taskStatus);
		Task<ApiResponse> UpdateTaskSectionAsync(Guid taskId, string taskSection);
		Task<ApiResponse<decimal>> GetTaskPredictedDurationAsync(Guid taskId);
	}
}
