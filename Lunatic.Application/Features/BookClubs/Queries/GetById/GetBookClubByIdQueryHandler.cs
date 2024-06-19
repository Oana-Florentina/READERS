
using Lunatic.Application.Persistence;
using MediatR;
using Lunatic.Application.Features.BookClubs.Mapper;





namespace Lunatic.Application.Features.BookClubs.Queries.GetById
{
    public class GetBookClubByIdQueryHandler : IRequestHandler<GetBookClubByIdQuery, GetBookClubByIdQueryResponse>
    {
        private readonly IBookClubRepository bookClubRepository;

        public GetBookClubByIdQueryHandler(IBookClubRepository bookClubRepository)
        {
            this.bookClubRepository = bookClubRepository;
        }

        public async Task<GetBookClubByIdQueryResponse> Handle(GetBookClubByIdQuery request, CancellationToken cancellationToken)
        {
            GetBookClubByIdQueryResponse response = new GetBookClubByIdQueryResponse();
            var bookClubResult = await this.bookClubRepository.FindByIdAsync(request.BookClubId);

            if (!bookClubResult.IsSuccess)
            {
                return new GetBookClubByIdQueryResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "BookClub not found" }
                };
            }

            return new GetBookClubByIdQueryResponse
            {
                Success = true,
                BookClub = BookClubMapper.MapToBookClubDto(bookClubResult.Value)
            };
        }


    }
}
