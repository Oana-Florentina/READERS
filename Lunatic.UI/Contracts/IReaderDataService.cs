using Lunatic.UI.Services.Responses.Reader;
using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IReaderDataService
    {
        Task<AddReaderResponse> AddReaderAsync(ReaderViewModel readerViewModel);
        Task<GetReaderByBookIdAndUserIdResponse> GetReaderByBookIdAndUserIdAsync(Guid bookId, Guid userId);
        Task<List<ReaderViewModel>> GetReadersByUserIdAsync(Guid userId);


    }
}
