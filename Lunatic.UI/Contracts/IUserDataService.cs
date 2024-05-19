using Lunatic.UI.Models.Dtos;
using Lunatic.UI.Models.ViewModels;
using Lunatic.UI.Services.Responses;

namespace Lunatic.UI.Contracts {
	public interface IUserDataService {
		Task<ApiResponse<UserDto>> GetUserByIdAsync(Guid id);
		Task<List<UsernameMatchDto>> GetUsersByUsernameAsync(string usernameMatch);
		Task<ApiResponse> UpdateUserInfoAsync(UpdateUserInfoViewModel user);
		Task<ApiResponse> ResetUserPasswordAsync();
		Task<ApiResponse> ChangeUserPasswordAsync(Guid id, ChangeUserPasswordDto changeUserPasswordDto);
	}
}
