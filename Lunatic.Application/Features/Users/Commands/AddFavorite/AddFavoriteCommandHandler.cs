using Lunatic.Application.Features.Users.Commands.UpdateUser;
using Lunatic.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.AddFavorite
{

    public class AddFavoriteCommandHandler : IRequestHandler<AddFavoriteCommand, AddFavoriteCommandResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IBookRepository bookRepository;

        public AddFavoriteCommandHandler(IUserRepository userRepository, IBookRepository bookRepository)
        {
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;

        }

        public async Task<AddFavoriteCommandResponse> Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddFavoriteCommandValidator(this.userRepository, this.bookRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new AddFavoriteCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var userResult = await this.userRepository.FindByIdAsync(request.UserId);
            if (!userResult.IsSuccess)
            {
                return new AddFavoriteCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "User not found" }
                };
            }

            userResult.Value.AddFavorite(request.BookId);

            var dbUserResult = await this.userRepository.UpdateAsync(userResult.Value);

            return new AddFavoriteCommandResponse
            {
                Success = true
            };


        }
    }
}
