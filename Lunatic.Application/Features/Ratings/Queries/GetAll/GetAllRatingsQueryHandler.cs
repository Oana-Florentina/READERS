using Lunatic.Application.Features.Ratings.Payload;
using Lunatic.Application.Features.Ratings.Queries.GetAll;
using Lunatic.Application.Features.Ratings.Mapper;
using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Ratings.Queries.GetAll
{
    public class GetAllRatingsQueryHandler : IRequestHandler<GetAllRatingsQuery, GetAllRatingsQueryResponse>
    {
        private readonly IRatingRepository ratingRepository;

        public GetAllRatingsQueryHandler(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        public async Task<GetAllRatingsQueryResponse> Handle(GetAllRatingsQuery request, CancellationToken cancellationToken)
        {
            GetAllRatingsQueryResponse response = new GetAllRatingsQueryResponse();
            var ratings = await this.ratingRepository.GetAllAsync();

            if (ratings.IsSuccess)
            {
                response.Ratings = ratings.Value.Select(rating => RatingMapper.MapToRatingDto(rating)).ToList();
            }
            return response;
        }
    }
}
