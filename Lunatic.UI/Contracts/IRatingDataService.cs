using Lunatic.UI.Payload;
using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatic.UI.Contracts
{
    public interface IRatingDataService
    {
        Task<List<RatingViewModel>> GetRatingsAsync();
        Task<RatingViewModel> GetRatingByIdAsync(Guid ratingId);

        Task<ApiResponse<RatingViewModel>> CreateRatingAsync(RatingViewModel ratingViewModel);
        Task<ApiResponse<RatingViewModel>> UpdateRatingAsync(Guid ratingId, RatingViewModel ratingViewModel);
        Task<ApiResponse<RatingViewModel>> DeleteRatingAsync(Guid ratingId);

        Task<AddRatingResponse> AddRatingAsync(RatingViewModel ratingViewModel);
    }
}
