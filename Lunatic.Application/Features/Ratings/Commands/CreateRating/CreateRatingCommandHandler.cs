
using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Application.Features.Ratings.Payload;
using MediatR;
using Lunatic.Application.Features.Books.Mapper;
using static System.Reflection.Metadata.BlobBuilder;
using Lunatic.Application.Features.Ratings.Mapper;
using Lunatic.Application.Features.Users.Commands.CreateUser;
using Lunatic.Application.Features.Users.Payload;


namespace Lunatic.Application.Features.Ratings.Commands.CreateRating
{
    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, CreateRatingCommandResponse>
    {
        private readonly IRatingRepository ratingRepository;
        private readonly IBookRepository bookRepository;
        private readonly IUserRepository userRepository;

        public CreateRatingCommandHandler(IRatingRepository ratingRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            this.ratingRepository = ratingRepository;
            this.bookRepository = bookRepository;
            this.userRepository = userRepository;
        }

        public async Task<CreateRatingCommandResponse> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRatingCommandValidator(this.ratingRepository, this.bookRepository, this.userRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new CreateRatingCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var rating = new Rating(
                request.BookId,
                request.UserId,
                request.Score,
                request.CommentMessage
            );

            await this.ratingRepository.AddAsync(rating);
            var Book = await this.bookRepository.FindByIdAsync(request.BookId);
            Book.Value.AddRating(rating.RatingId);
            var dbBookResult = await this.bookRepository.UpdateAsync(Book.Value);
            return new CreateRatingCommandResponse
            {
                Success = true,
                Rating = RatingMapper.MapToRatingDto(rating)
            };
        }
    }
}
