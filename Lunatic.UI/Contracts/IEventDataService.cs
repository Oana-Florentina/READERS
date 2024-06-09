using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IEventDataService
    {
        Task<List<EventViewModel>> GetEventsAsync();
        Task<EventViewModel> GetEventByIdAsync(Guid id);
        Task<ApiResponse<Guid>> CreateEventAsync(EventViewModel eventViewModel);
        Task<ApiResponse<Guid>> UpdateEventAsync(EventViewModel eventViewModel);
        Task<ApiResponse<Guid>> DeleteEventAsync(Guid id);
    }
}
