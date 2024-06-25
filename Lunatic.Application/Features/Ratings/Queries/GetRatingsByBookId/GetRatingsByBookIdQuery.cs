using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Ratings.Queries.GetRatingsByBookId
{
   
    public record GetRatingsByBookIdQuery(Guid BookId) : IRequest<GetRatingsByBookIdQueryResponse>;
}
