using FluentValidation;
using Lunatic.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.AddReader
{
    internal class AddReaderCommandValidator : AbstractValidator<AddReaderCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IReaderRepository readerRepository;

        public AddReaderCommandValidator(IUserRepository userRepository, IReaderRepository readerRepository)
        {
            this.userRepository = userRepository;
            this.readerRepository = readerRepository;

            RuleFor(request => request.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (userId, cancellationToken) => await this.userRepository.ExistsByIdAsync(userId))
                .WithMessage("{PropertyName} must exist.");

            RuleFor(request => request.ReaderId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull().WithMessage("{PropertyName} is required.")
               .MustAsync(async (readerId, cancellationToken) => await this.readerRepository.ExistsByIdAsync(readerId))
               .WithMessage("{PropertyName} must exists.");
        }
    }
}
