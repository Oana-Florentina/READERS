using Lunatic.Application.Responses;
using Lunatic.Application.Features.Ratings.Mapper;
using Lunatic.Application.Features.Ratings.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Ratings.Queries.GetRatingsByBookId
{
    
    public class GetRatingsByBookIdQueryResponse : ResponseBase
    {
        public List<RatingDto> Ratings { get; set; } = new List<RatingDto>();
    }
}
