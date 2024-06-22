using Lunatic.Application.Features.Users.Commands.AddBookClub;
using Lunatic.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.AddBookClub
{

    public class AddBookClubToUserCommandHandler : IRequestHandler<AddBookClubToUserCommand, AddBookClubToUserCommandResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IBookClubRepository bookClubRepository;

        public AddBookClubToUserCommandHandler(IUserRepository userRepository, IBookClubRepository bookClubRepository)
        {
            this.userRepository = userRepository;
            this.bookClubRepository = bookClubRepository;

        }

        public async Task<AddBookClubToUserCommandResponse> Handle(AddBookClubToUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddBookClubToUserCommandValidator(this.userRepository, this.bookClubRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new AddBookClubToUserCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var userResult = await this.userRepository.FindByIdAsync(request.UserId);
            if (!userResult.IsSuccess)
            {
                return new AddBookClubToUserCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "User not found" }
                };
            }

            userResult.Value.AddBookClub(request.BookClubId);
            var bookClubResult = await this.bookClubRepository.FindByIdAsync(request.BookClubId);
            bookClubResult.Value.addMember(request.UserId);
            var dbBookClubResult = await this.bookClubRepository.UpdateAsync(bookClubResult.Value);

            var dbUserResult = await this.userRepository.UpdateAsync(userResult.Value);

            return new AddBookClubToUserCommandResponse
            {
                Success = true
            };


        }
    }
}
