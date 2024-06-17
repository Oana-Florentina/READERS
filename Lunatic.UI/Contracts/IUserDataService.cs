using Lunatic.Domain.Entities;
using Lunatic.UI.Services.Responses;
using Lunatic.UI.Services.Responses.Favorites;
using Lunatic.UI.Services.Responses.FriendRequest;
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
        Task<bool> IsBookFavorite(Guid userId, Guid bookId);
        Task<AddReaderToUserResponse> AddReaderToUserAsync(Guid userId, Guid readerId);
        Task<AddWantToReadResponse> AddWantToReadAsync(Guid userId, Guid bookId);
        Task<AddToFavoritesResponse> AddToFavoritesAsync(Guid userId, Guid bookId);
        Task<SendFriendRequestCommandResponse> SendFriendRequestAsync(Guid senderId, Guid receiverId);
        Task<List<FriendRequestViewModel>> GetFriendRequestsByUserIdAsync(Guid userId);
        Task<Response> DeleteFriendRequestAsync(Guid requestId, bool status);
        Task<List<UserViewModel>> GetFriendsByUserIdAsync(Guid userId);
       
        Task<SendFriendRecommandationResponse> SendFriendRecommandationAsync(FriendRecommandationViewModel recommandation);


    }
}
