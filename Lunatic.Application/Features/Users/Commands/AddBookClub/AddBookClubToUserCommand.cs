using Lunatic.Application.Features.Users.Commands.AddReader;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.AddBookClub
{
    public class AddBookClubToUserCommand : IRequest<AddBookClubToUserCommandResponse>
    {
        public Guid UserId { get; set; } = default!;
        public Guid BookClubId { get; set; } = default!;
    }
}
