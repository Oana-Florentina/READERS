
using Lunatic.Application.Persistence;
using MediatR;


namespace Lunatic.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, DeleteBookCommandResponse>
    {
        private readonly IBookRepository bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<DeleteBookCommandResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var result = await this.bookRepository.DeleteAsync(request.BookId);

            if (!result.IsSuccess)
            {
                return new DeleteBookCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };

            }
            return new DeleteBookCommandResponse
            {
                Success = true
            };
        }
    }
}
