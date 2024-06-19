using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Application.Features.BookClubs.Payload;
using MediatR;



namespace Lunatic.Application.Features.BookClubs.Commands.CreateBookClub
{
    public class CreateBookClubCommandHandler : IRequestHandler<CreateBookClubCommand, CreateBookClubCommandResponse>
    {
        private readonly IBookClubRepository bookClubRepository;

        public CreateBookClubCommandHandler(IBookClubRepository bookClubRepository)
        {
            this.bookClubRepository = bookClubRepository;
        }

        public async Task<CreateBookClubCommandResponse> Handle(CreateBookClubCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateBookClubCommandValidator(this.bookClubRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new CreateBookClubCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var bookClub = new BookClub(request.Title, request.Description);
            await this.bookClubRepository.AddAsync(bookClub);

            return new CreateBookClubCommandResponse
            {
                Success = true,
                BookClub = new BookClubDto
                {
                    BookClubId = bookClub.BookClubId,
                    Title = bookClub.Title,
                    Description = bookClub.Description,
                }
            };
        }
    }
}
