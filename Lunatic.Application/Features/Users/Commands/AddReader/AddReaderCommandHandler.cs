using Lunatic.Application.Features.Users.Commands.AddReader;
using Lunatic.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.AddReader
{
    
    public class AddReaderCommandHandler : IRequestHandler<AddReaderCommand, AddReaderCommandResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IReaderRepository readerRepository;

        public AddReaderCommandHandler(IUserRepository userRepository, IReaderRepository readerRepository)
        {
            this.userRepository = userRepository;
            this.readerRepository = readerRepository;

        }

        public async Task<AddReaderCommandResponse> Handle(AddReaderCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddReaderCommandValidator(this.userRepository, this.readerRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new AddReaderCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var userResult = await this.userRepository.FindByIdAsync(request.UserId);
            if (!userResult.IsSuccess)
            {
                return new AddReaderCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "User not found" }
                };
            }

            userResult.Value.AddReader(request.UserId, request.ReaderId);

            var dbUserResult = await this.userRepository.UpdateAsync(userResult.Value);

            return new AddReaderCommandResponse
            {
                Success = true
            };


        }
    }
}
