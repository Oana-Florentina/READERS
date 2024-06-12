using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetWantToRead
{
    public record GetWantToReadQuery(Guid UserId) : IRequest<GetWantToReadQueryResponse>;
}
