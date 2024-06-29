using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.BookClubs.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<CreatePostCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid BookClubId { get; set; }
        public string ?Text { get; set; }
    }
}
