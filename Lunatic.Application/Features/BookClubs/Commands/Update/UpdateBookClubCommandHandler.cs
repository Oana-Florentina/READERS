using Lunatic.Application.Features.BookClubs.Commands.Update;
using Lunatic.Application.Persistence;
using MediatR;


namespace Lunatic.Application.Features.BookClubs.Commands.Update
{
    public class UpdateBookClubCommandHandler : IRequestHandler<UpdateBookClubCommand, UpdateBookClubCommandResponse>
    {
        private readonly IBookClubRepository bookClubRepository;

        public UpdateBookClubCommandHandler(IBookClubRepository bookClubRepository)
        {
            this.bookClubRepository = bookClubRepository;
        }

        public async Task<UpdateBookClubCommandResponse> Handle(UpdateBookClubCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBookClubCommandValidator(this.bookClubRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new UpdateBookClubCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var bookClubResult = await this.bookClubRepository.FindByIdAsync(request.BookClub);
            if (!bookClubResult.IsSuccess)
            {
                return new UpdateBookClubCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "BookClub not found" }
                };
            }

            bookClubResult.Value.Update(request.Title, request.Description, request.Members, request.Books );

            var dbBookClubResult = await this.bookClubRepository.UpdateAsync(bookClubResult.Value);

            return new UpdateBookClubCommandResponse
            {
                Success = true
            };


        }
    }
}
