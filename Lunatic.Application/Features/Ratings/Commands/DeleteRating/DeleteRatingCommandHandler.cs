
using Lunatic.Application.Features.Ratings.Commands.DeleteRating;
using Lunatic.Application.Persistence;
using MediatR;


namespace Lunatic.Ratings.Features.DeleteRating.Commands.DeleteRating
{
    public class DeleteRatingCommandHandler : IRequestHandler<DeleteRatingCommand, DeleteRatingCommandResponse>
    {
        private readonly IRatingRepository ratingRepository;

        public DeleteRatingCommandHandler(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        public async Task<DeleteRatingCommandResponse> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var result = await this.ratingRepository.DeleteAsync(request.RatingId);

            if (!result.IsSuccess)
            {
                return new DeleteRatingCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };

            }
            return new DeleteRatingCommandResponse
            {
                Success = true
            };
        }
    }
}
