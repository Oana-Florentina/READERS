
using Lunatic.Application.Persistence;
using MediatR;


namespace Lunatic.Application.Features.Readers.Commands.DeleteReader
{
    public class DeleteReaderCommandHandler : IRequestHandler<DeleteReaderCommand, DeleteReaderCommandResponse>
    {
        private readonly IReaderRepository readerRepository;

        public DeleteReaderCommandHandler(IReaderRepository readerRepository)
        {
            this.readerRepository = readerRepository;
        }

        public async Task<DeleteReaderCommandResponse> Handle(DeleteReaderCommand request, CancellationToken cancellationToken)
        {
            var result = await this.readerRepository.DeleteAsync(request.ReaderId);

            if (!result.IsSuccess)
            {
                return new DeleteReaderCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };

            }
            return new DeleteReaderCommandResponse
            {
                Success = true
            };
        }
    }
}
