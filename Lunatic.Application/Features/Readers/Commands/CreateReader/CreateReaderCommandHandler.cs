
using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Application.Features.Readers.Payload;
using MediatR;
using Lunatic.Application.Features.Books.Mapper;
using static System.Reflection.Metadata.BlobBuilder;
using Lunatic.Application.Features.Readers.Mapper;
using Lunatic.Application.Features.Users.Commands.CreateUser;
using Lunatic.Application.Features.Users.Payload;


namespace Lunatic.Application.Features.Readers.Commands.CreateReader
{
    public class CreateReaderCommandHandler : IRequestHandler<CreateReaderCommand, CreateReaderCommandResponse>
    {
        private readonly IReaderRepository readerRepository;

        public CreateReaderCommandHandler(IReaderRepository readerRepository)
        {
            this.readerRepository = readerRepository;
        }

        public async Task<CreateReaderCommandResponse> Handle(CreateReaderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateReaderCommandValidator(this.readerRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new CreateReaderCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var reader = new Reader(
                request.BookId,
                request.UserId,
                request.StartDate,
                request.EndDate,
                request.RatingId,
                request.IsFavorite
            );

            await this.readerRepository.AddAsync(reader);

            return new CreateReaderCommandResponse
            {
                Success = true,
                Reader = ReaderMapper.MapToReaderDto(reader)
            };
        }
    }
}
