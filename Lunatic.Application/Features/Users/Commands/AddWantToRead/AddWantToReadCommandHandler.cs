using Lunatic.Application.Features.Users.Commands.UpdateUser;
using Lunatic.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.AddWantToRead
{
   
    public class AddWantToReadCommandHandler : IRequestHandler<AddWantToReadCommand, AddWantToReadCommandResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IBookRepository bookRepository;

        public AddWantToReadCommandHandler(IUserRepository userRepository, IBookRepository bookRepository)
        {
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;

        }

        public async Task<AddWantToReadCommandResponse> Handle(AddWantToReadCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddWantToReadCommandValidator(this.userRepository, this.bookRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new AddWantToReadCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var userResult = await this.userRepository.FindByIdAsync(request.UserId);
            if (!userResult.IsSuccess)
            {
                return new AddWantToReadCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "User not found" }
                };
            }

            userResult.Value.AddWantToRead(request.BookId);

            var dbUserResult = await this.userRepository.UpdateAsync(userResult.Value);

            return new AddWantToReadCommandResponse
            {
                Success = true
            };


        }
    }
}
