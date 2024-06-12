using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IUserDataService
    {
        Task<List<UserViewModel>> GetUsersAsync();
        Task<ProfileViewModel> GetUserByIdAsync(Guid userId);

        Task<List<BookViewModel>> GetBooksByIdsAsync(List<Guid> bookIds);
    }
}
