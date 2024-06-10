using Lunatic.UI.Payload;
using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IBookDataService
    {
        Task<List<BookViewModel>> GetBooksAsync();

        Task<ApiResponse<BookDto>> CreateBookAsync(BookViewModel bookViewModel);
    }
}
