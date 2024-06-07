using Lunatic.Application.Features.Ratings.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Ratings.Queries.GetAll
{
    public class GetAllRatingsQueryResponse
    {
        public List<RatingDto> Ratings { get; set; } = default!;
    }
}
