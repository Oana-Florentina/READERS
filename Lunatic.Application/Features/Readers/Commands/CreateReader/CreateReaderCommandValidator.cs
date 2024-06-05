
using Lunatic.Application.Persistence;
using FluentValidation;


namespace Lunatic.Application.Features.Readers.Commands.CreateReader
{
    internal class CreateReaderCommandValidator : AbstractValidator<CreateReaderCommand>
    {
        private readonly IReaderRepository readerRepository;

        public CreateReaderCommandValidator(IReaderRepository readerRepository)
        {
            this.readerRepository = readerRepository;                 
        }
    }
}
