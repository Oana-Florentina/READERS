using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lunatic.Application.Features.BookClubs.Payload;
using Lunatic.Application.Responses;

namespace Lunatic.Application.Features.BookClubs.Commands.CreatePost
{
    public class CreatePostCommandResponse : ResponseBase
    {
        public CreatePostCommandResponse() : base() { }

        public PostDto Post { get; set; } = default!;
    }
}
