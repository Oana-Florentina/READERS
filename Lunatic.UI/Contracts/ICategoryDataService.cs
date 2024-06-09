using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetCategoriesAsync();

        Task<ApiResponse<CategoryDto>> CreateCategoryAsync(CategoryViewModel categoryViewModel);
    }
}
