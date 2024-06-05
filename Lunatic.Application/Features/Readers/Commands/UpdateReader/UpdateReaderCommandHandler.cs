
using Lunatic.Application.Features.Readers.Mapper;
using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using MediatR;


namespace Lunatic.Application.Features.Readers.Commands.UpdateReader
{
    public class UpdateReaderCommandHandler : IRequestHandler<UpdateReaderCommand, UpdateReaderCommandResponse>
    {
        private readonly IReaderRepository readerRepository;
        private readonly IBookRepository bookRepository;
        private readonly IUserRepository userRepository;

        public UpdateReaderCommandHandler(IReaderRepository readerRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            this.readerRepository = readerRepository;
            this.bookRepository = bookRepository;
            this.userRepository = userRepository;
        }

        public async Task<UpdateReaderCommandResponse> Handle(UpdateReaderCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateReaderCommandValidator(this.readerRepository, this.bookRepository, this.userRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new UpdateReaderCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var readerResult = await this.readerRepository.FindByIdAsync(request.ReaderId);
            if (!readerResult.IsSuccess)
            {
                return new UpdateReaderCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "Reader not found" }
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

            return new UpdateReaderCommandResponse
            {
                Success = true,
                Reader = ReaderMapper.MapToReaderDto(reader)
            };

        }
    }
}
