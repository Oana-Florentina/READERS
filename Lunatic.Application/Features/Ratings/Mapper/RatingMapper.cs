﻿using Lunatic.Application.Features.Ratings.Payload;
using Lunatic.Domain.Entities;

namespace Lunatic.Application.Features.Ratings.Mapper
{
    public class RatingMapper
    {

        public static RatingDto MapToRatingDto(Rating rating)
        {
            return new RatingDto
            {
               RatingId = rating.RatingId,
               BookId = rating.BookId,
               UserId = rating.UserId,
               Score = rating.Score,
               CommentMessage = rating.CommentMessage


            };
        }
    }
}
