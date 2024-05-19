using Lunatic.UI.Models.Dtos;
using Lunatic.UI.Services.Responses;

namespace Lunatic.UI.Contracts {
	public interface IImageService {
		public Task<ApiResponse<ImageDto>> GetUserImageAsync(string username);
		public Task<ApiResponse<ImageDto>> UploadUserImageAsync(string username, HttpContent uploadImageDto);
	}
}
