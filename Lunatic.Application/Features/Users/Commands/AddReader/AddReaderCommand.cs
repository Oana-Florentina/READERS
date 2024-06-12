using Lunatic.Application.Features.Users.Commands.UpdateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.AddReader
{
    public class AddReaderCommand : IRequest<AddReaderCommandResponse>
    {
        public Guid UserId { get; set; } = default!;

    }
}
