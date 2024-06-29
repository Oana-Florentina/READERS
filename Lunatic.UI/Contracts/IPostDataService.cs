using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IPostDataService
    {
        Task<PostViewModel> GetPostByIdAsync(Guid postId);
    }
}
