using Lunatic.Application.Features.Books.Mapper;
using Lunatic.Application.Features.Books.Payload;
using Lunatic.Application.Features.Users.Queries.GetWantToRead;
using Lunatic.Application.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetWantToRead
{
    public class GetWantToReadQueryHandler : IRequestHandler<GetWantToReadQuery, GetWantToReadQueryResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IBookRepository bookRepository;

        public GetWantToReadQueryHandler(IUserRepository userRepository, IBookRepository bookRepository)
        {
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;
        }

        public async Task<GetWantToReadQueryResponse> Handle(GetWantToReadQuery request, CancellationToken cancellationToken)
        {
            // Fetch the user by Id
            var userResult = await userRepository.FindByIdAsync(request.UserId);

            if (!userResult.IsSuccess || userResult.Value == null)
            {
                return new GetWantToReadQueryResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "User not found" }
                };
            }

            var user = userResult.Value;
            var wantToReadBookIds = user.WantToReadIds;

            if (wantToReadBookIds == null || !wantToReadBookIds.Any())
            {
                return new GetWantToReadQueryResponse
                {
                    Success = true, // Success but empty list
                    Books = new List<BookDto>()
                };
            }

            // Fetch book details for each book ID
            var books = new List<BookDto>();
            foreach (var bookId in wantToReadBookIds)
            {
                var bookResult = await bookRepository.FindByIdAsync(bookId);
                if (bookResult.IsSuccess && bookResult.Value != null)
                {
                    books.Add(BookMapper.MapToBookDto(bookResult.Value));
                }
                else
                {
                    // Optionally handle book fetch failure, log or continue without this book
                }
            }

            return new GetWantToReadQueryResponse
            {
                Success = true,
                Books = books
            };
        }
    }
}
