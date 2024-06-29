using Lunatic.Application.Features.Users.Queries.GetById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Posts.Queries.GetPostById
{
    public record GetPostByIdQuery(Guid PostId) : IRequest<GetPostByIdQueryResponse>;
}
