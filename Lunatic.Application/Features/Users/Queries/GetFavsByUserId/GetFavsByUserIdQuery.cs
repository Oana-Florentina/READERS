using Lunatic.Application.Features.Users.Queries.GetWantToRead;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Users.Queries.GetFavsByUserId
{
    
    public record GetFavsByUserIdQuery(Guid UserId) : IRequest<GetFavsByUserIdQueryResponse>;
}
