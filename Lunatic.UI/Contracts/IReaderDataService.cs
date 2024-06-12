using Lunatic.UI.Services.Responses.Reader;
using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IReaderDataService
    {
        Task<AddReaderResponse> AddReaderAsync(ReaderViewModel readerViewModel);

    }
}
