
using Lunatic.Domain.Entities;
using MediatR;


namespace Lunatic.Application.Features.Readers.Commands.UpdateReader
{
    public class UpdateReaderCommand : IRequest<UpdateReaderCommandResponse>
    {
       
        public Guid ReaderId { get; set; } = default!;
        public Guid BookId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
        public DateTime StartDate { get; set; } = default;
        public DateTime EndDate { get;  set; } = default;
        public Guid RatingId { get;  set; } = default;
        public bool IsFavorite { get;  set; } = default;
    }
}
