using Lunatic.Application.Features.BookClubs.Payload;
using Lunatic.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.BookClubs.Commands
{
    public class CreateBookClubCommandResponse : ResponseBase
    {
        public CreateBookClubCommandResponse() : base() { }

        public BookClubDto BookClub { get; set; } = default!;
    }
}
