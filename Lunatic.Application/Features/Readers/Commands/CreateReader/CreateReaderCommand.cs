
using Lunatic.Application.Features.Readers.Commands.CreateReader;
using Lunatic.Domain.Entities;
using MediatR;


namespace Lunatic.Application.Features.Readers.Commands.CreateReader
{
    public class CreateReaderCommand : IRequest<CreateReaderCommandResponse>
    {
        public Guid BookId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
        public DateTime StartDate { get; set; } = default;
        public DateTime EndDate { get;  set; } = default;
        public Guid RatingId { get;  set; } = default;
        public bool IsFavorite { get;  set; } = default;
    }
}
