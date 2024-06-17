using Lunatic.UI.Payload;
using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IBookDataService
    {
        Task<List<BookViewModel>> GetBooksAsync();
        Task<BookViewModel> GetBookByIdAsync(Guid bookId);
        Task<ApiResponse<BookDto>> CreateBookAsync(BookViewModel bookViewModel);
        Task<List<BookViewModel>> GetPopularBooksAsync();
    }
}
