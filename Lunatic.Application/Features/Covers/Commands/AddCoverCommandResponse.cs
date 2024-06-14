using Lunatic.Application.Features.Cover.Payload;
using Lunatic.Application.Responses;


namespace Lunatic.Application.Features.Cover.Commands
{
    public class AddCoverCommandResponse : ResponseBase
    {
        public AddCoverCommandResponse() : base() { }

        public CoverDto Cover { get; set; } = default!;
    }
}
