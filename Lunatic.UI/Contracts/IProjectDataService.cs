using Lunatic.UI.Models.Dtos;
using Lunatic.UI.Models.ViewModels;
using Lunatic.UI.Services.Responses;

namespace Lunatic.UI.Contracts {
	public interface IProjectDataService {
		Task<ApiResponse<ProjectDto>> CreateProjectAsync(ProjectViewModel Project);
		Task<ApiResponse> EditProjectInfoAsync(Guid projectId, EditProjectDto project);
		Task<ApiResponse> DeleteProjectAsync(Guid teamId, Guid projectId);
		Task<ApiResponse<ProjectDto>> GetProjectByIdAsync(Guid teamId);
		Task<ApiResponse<List<TaskDto>>> GetProjectTasksAsync(Guid projectId);

		Task<ApiResponse> AddSectionAsync(Guid projectId, string sectionTitle);
		Task<ApiResponse> RenameSectionAsync(Guid projectId, string oldSection, string newSection);
		Task<ApiResponse> DeleteSectionAsync(Guid projectId, string sectionTitle);

	}
}

