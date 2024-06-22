using Lunatic.Application.Features.BookClubs.Mapper;
using Lunatic.Application.Features.BookClubs.Payload;
using Lunatic.Application.Features.Users.Queries.GetBookClubs;
using Lunatic.Application.Persistence;
using MediatR;


namespace Lunatic.Application.Features.Users.Queries.GetBookClubs
{
    public class GetBookClubsByUserIdQueryHandler : IRequestHandler<GetBookClubsByUserIdQuery, GetBookClubsByUserIdQueryResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IBookClubRepository bookClubRepository;

        public GetBookClubsByUserIdQueryHandler(IUserRepository userRepository, IBookClubRepository bookClubRepository)
        {
            this.userRepository = userRepository;
            this.bookClubRepository = bookClubRepository;
        }

        public async Task<GetBookClubsByUserIdQueryResponse> Handle(GetBookClubsByUserIdQuery request, CancellationToken cancellationToken)
        {
            // Fetch the user by Id
            var userResult = await userRepository.FindByIdAsync(request.UserId);

            if (!userResult.IsSuccess || userResult.Value == null)
            {
                return new GetBookClubsByUserIdQueryResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "User not found" }
                };
            }

            var user = userResult.Value;
            var bookClubIds = user.BookClubIds;

            if (bookClubIds == null || !bookClubIds.Any())
            {
                return new GetBookClubsByUserIdQueryResponse
                {
                    Success = true, // Success but empty list
                    BookClubs = new List<BookClubDto>()
                };
            }

            // Fetch bookClub details for each bookClub ID
            var bookClubs = new List<BookClubDto>();
            foreach (var bookClubId in bookClubIds)
            {
                var bookClubResult = await bookClubRepository.FindByIdAsync(bookClubId);
                if (bookClubResult.IsSuccess && bookClubResult.Value != null)
                {
                    bookClubs.Add(BookClubMapper.MapToBookClubDto(bookClubResult.Value));
                }
                else
                {
                    // Optionally handle bookClub fetch failure, log or continue without this bookClub
                }
            }

            return new GetBookClubsByUserIdQueryResponse
            {
                Success = true,
                BookClubs = bookClubs
            };
        }
    }
}
