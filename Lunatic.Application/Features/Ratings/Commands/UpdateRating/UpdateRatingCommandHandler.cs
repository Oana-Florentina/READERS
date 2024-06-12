
using Lunatic.Application.Features.Ratings.Mapper;
using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using MediatR;


namespace Lunatic.Application.Features.Ratings.Commands.UpdateRating
{
    public class UpdateRatingCommandHandler : IRequestHandler<UpdateRatingCommand, UpdateRatingCommandResponse>
    {
        private readonly IRatingRepository ratingRepository;
        private readonly IBookRepository bookRepository;
        private readonly IUserRepository userRepository;

        public UpdateRatingCommandHandler(IRatingRepository ratingRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            this.ratingRepository = ratingRepository;
            this.bookRepository = bookRepository;
            this.userRepository = userRepository;
        }

        public async Task<UpdateRatingCommandResponse> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRatingCommandValidator(this.ratingRepository, this.bookRepository, this.userRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new UpdateRatingCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var ratingResult = await this.ratingRepository.FindByIdAsync(request.RatingId);
            if (!ratingResult.IsSuccess)
            {
                return new UpdateRatingCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "Rating not found" }
                };
            }
            var rating = new Rating(
               request.BookId,
               request.UserId,
               request.Score,
               request.CommentMessage
           );

            await this.ratingRepository.AddAsync(rating);

            return new UpdateRatingCommandResponse
            {
                Success = true,
                Rating = RatingMapper.MapToRatingDto(rating)
            };

        }
    }
}
