using MediatR;

namespace Lunatic.Application.Features.BookClubs.Commands
{
    public class CreateBookClubCommand : IRequest<CreateBookClubCommandResponse>
    {

        public string Title { get; set; } = default!;
        public string Description { get;  set; } = default!;
      
    }
}
