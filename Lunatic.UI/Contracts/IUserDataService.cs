using Lunatic.UI.Services.Responses;
using Lunatic.UI.Services.Responses.Favorites;
using Lunatic.UI.Services.Responses.Reader;
using Lunatic.UI.Services.Responses.WantToRead;
using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IUserDataService
    {
        Task<List<UserViewModel>> GetUsersAsync();
        Task<ProfileViewModel> GetUserByIdAsync(Guid userId);

        Task<List<BookViewModel>> GetBooksIWantToReadByIdsAsync(Guid userId);
        Task<List<BookViewModel>> GetBooksIReadByIdsAsync(Guid userId);
        Task<List<BookViewModel>> GetFavsByUserIdAsync(Guid userId);
        Task<AddReaderToUserResponse> AddReaderToUserAsync(Guid userId, Guid readerId);
        Task<AddWantToReadResponse> AddWantToReadAsync(Guid userId, Guid bookId);
        Task<AddToFavoritesResponse> AddToFavoritesAsync(Guid userId, Guid bookId);
    }
}
