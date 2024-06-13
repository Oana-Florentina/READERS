using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Commands.AddFavorite
{
    public class AddFavoriteCommand: IRequest <AddFavoriteCommandResponse>
    {
        public Guid BookId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
    }
}
