using Lunatic.UI.Services.Responses;
using Lunatic.UI.Services.Responses.Reader;
using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IUserDataService
    {
        Task<List<UserViewModel>> GetUsersAsync();
        Task<ProfileViewModel> GetUserByIdAsync(Guid userId);

        Task<List<BookViewModel>> GetBooksIWantToReadByIdsAsync(Guid userId);
        Task<List<BookViewModel>> GetBooksIReadByIdsAsync(Guid userId);
        Task<AddReaderToUserResponse> AddReaderToUserAsync(Guid userId, Guid readerId);
    }
}
