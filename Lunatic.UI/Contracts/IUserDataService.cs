using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IUserDataService
    {
        Task<List<UserViewModel>> GetUsersAsync();
        Task<ProfileViewModel> GetUserByIdAsync(Guid userId);

        Task<List<BookViewModel>> GetBooksIWantToReadByIdsAsync(Guid userId);
        Task<List<BookViewModel>> GetBooksIReadByIdsAsync(Guid userId);
        Task<AddReaderResponse> AddReaderAsync(ReaderViewModel readerViewModel, Guid userId);

    }
}
