
using Lunatic.Application.Persistence;
using MediatR;


namespace Lunatic.Application.Features.Users.Commands.UpdateUser 
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse> {
        private readonly IUserRepository userRepository;
        private readonly IBookClubRepository bookClubRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository, IBookClubRepository bookClubRepository) {
            this.userRepository = userRepository;
            this.bookClubRepository = bookClubRepository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken) {
            var validator = new UpdateUserCommandValidator(this.userRepository, this.bookClubRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validatorResult.IsValid) {
                return new UpdateUserCommandResponse {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var userResult = await this.userRepository.FindByIdAsync(request.UserId);
            if(!userResult.IsSuccess) {
                return new UpdateUserCommandResponse {
                    Success = false,
                    ValidationErrors = new List<string> { "User not found" }
                };
            }

            userResult.Value.Update(request.FirstName, request.LastName, request.Email, request.BookClub);

            var dbUserResult = await this.userRepository.UpdateAsync(userResult.Value);

            return new UpdateUserCommandResponse {
                Success = true
            };


        }
    }
}
