using Lunatic.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lunatic.Application.Features.BookClubs.Payload;
using Lunatic.Application.Features.BookClubs.Mapper;
namespace Lunatic.Application.Features.Posts.Queries.GetPostById
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, GetPostByIdQueryResponse>
    {
        private readonly IPostRepository postRepository;

        public GetPostByIdQueryHandler(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task<GetPostByIdQueryResponse> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var postResult = await this.postRepository.FindByIdAsync(request.PostId);
            if (!postResult.IsSuccess)
            {
                return new GetPostByIdQueryResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "Post not found" }
                };
            }

            return new GetPostByIdQueryResponse
            {
                Success = true,
                Post = PostMapper.MapToPostDto(postResult.Value)
            };
        }
    }
}
