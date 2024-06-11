using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IUserDataService
    {
        Task<List<UserViewModel>> GetUsersAsync();
    }
}
