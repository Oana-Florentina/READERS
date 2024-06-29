using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;
using Lunatic.UI.Payload;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatic.UI.Contracts
{
    public interface IBookClubDataService
    {
        Task<List<BookClubViewModel>> GetAllBookClubsAsync();
        Task<BookClubViewModel> GetBookClubByIdAsync(Guid bookClubId);
        Task<BookClubDto> CreateBookClubAsync(BookClubViewModel bookClub);
        Task<ApiResponse<BookClubViewModel>> UpdateBookClubAsync(BookClubViewModel bookClub);

        Task<PostDto> CreatePost(PostViewModel post, Guid bookClubId);
    }
}
