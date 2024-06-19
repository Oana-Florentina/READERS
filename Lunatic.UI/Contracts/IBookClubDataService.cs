using Lunatic.UI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatic.UI.Contracts
{
    public interface IBookClubDataService
    {
        Task<List<BookClubViewModel>> GetAllBookClubsAsync();
        Task<BookClubViewModel> GetBookClubByIdAsync(Guid bookClubId);
        Task<bool> JoinBookClub(ProfileViewModel CurrentUser, Guid bookClubId);
    }
}
