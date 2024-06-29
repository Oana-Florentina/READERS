using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lunatic.Application.Features.BookClubs.Payload;
using Lunatic.Application.Features.BookClubs.Mapper;
using Lunatic.Application.Responses;


namespace Lunatic.Application.Features.Posts.Queries.GetPostById
{
    public class GetPostByIdQueryResponse : ResponseBase
    {
        public GetPostByIdQueryResponse() : base() { }

        public PostDto Post { get; set; } = default!;
    }
}
