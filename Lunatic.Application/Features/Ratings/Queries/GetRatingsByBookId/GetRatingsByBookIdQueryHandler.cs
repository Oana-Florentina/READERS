using Lunatic.Application.Persistence;
using MediatR;
using Lunatic.Application.Features.Ratings.Mapper;
using Lunatic.Application.Features.Ratings.Payload;
using Lunatic.Application.Features.Ratings.Queries.GetRatingsByBookId;

namespace Lunatic.Application.Features.Ratings.Queries.GetById
{
    public class GetRatingsByBookIdQueryHandler : IRequestHandler<GetRatingsByBookIdQuery, GetRatingsByBookIdQueryResponse>
    {
        private readonly IRatingRepository ratingRepository;
        private readonly IBookRepository bookRepository;

        public GetRatingsByBookIdQueryHandler(IRatingRepository ratingRepository, IBookRepository bookRepository)
        {
            this.ratingRepository = ratingRepository;
            this.bookRepository = bookRepository;
        }

        public async Task<GetRatingsByBookIdQueryResponse> Handle(GetRatingsByBookIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetRatingsByBookIdQueryResponse();

            var bookResult = await this.bookRepository.FindByIdAsync(request.BookId);

            if (!bookResult.IsSuccess || bookResult.Value == null)
            {
                return new GetRatingsByBookIdQueryResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "Book not found" }
                };
            }
            var ratingResult = await this.ratingRepository.GetRatingsByBookIdAsync(request.BookId);

            if (ratingResult == null || !ratingResult.IsSuccess)
            {
                return new GetRatingsByBookIdQueryResponse
                {
                    Success = true,
                    Ratings = new List<RatingDto>()
                };
            }


            response.Success = true;
            response.Ratings = ratingResult.Value
                .Select(RatingMapper.MapToRatingDto)
                .ToList();

            return response;
        }
    }
}
