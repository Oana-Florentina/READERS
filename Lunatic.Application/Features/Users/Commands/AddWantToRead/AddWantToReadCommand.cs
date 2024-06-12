using Lunatic.Application.Features.Users.Commands.UpdateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.AddWantToRead
{
    public class AddWantToReadCommand : IRequest<AddWantToReadCommandResponse>
    {
        public Guid BookId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
    }
}
