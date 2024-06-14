using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Lunatic.Application.Features.Cover.Commands
{
    public class AddCoverCommand: IRequest<AddCoverCommandResponse>
    {
        public string Url { get; set; }
    }
}
