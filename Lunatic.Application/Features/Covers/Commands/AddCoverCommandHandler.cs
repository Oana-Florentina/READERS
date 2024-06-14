using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Application.Features.Cover.Payload;
using MediatR;
using Lunatic.Application.Features.Cover.Commands;


namespace Lunatic.Application.Features.Covers.Commands.AddCover
{
    public class AddCoverCommandHandler : IRequestHandler<AddCoverCommand, AddCoverCommandResponse>
    {
        private readonly ICoverRepository coverRepository;
        private readonly IBookRepository bookRepository;

        public AddCoverCommandHandler(ICoverRepository coverRepository, IBookRepository bookRepository)
        {
            this.coverRepository = coverRepository;
            this.bookRepository = bookRepository;
        }

        public async Task<AddCoverCommandResponse> Handle(AddCoverCommand request, CancellationToken cancellationToken)
        {

            var validator = new AddCoverCommandValidator(this.coverRepository, this.bookRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new AddCoverCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var cover = new CoverImage(request.Url);
            await this.coverRepository.AddAsync(cover);

            return new AddCoverCommandResponse
            {
                Success = true,
                Cover = new CoverDto
                {
                    CoverId = cover.CoverImageId,
                    Url = cover.Url
                }
            };
        }
    }
}
