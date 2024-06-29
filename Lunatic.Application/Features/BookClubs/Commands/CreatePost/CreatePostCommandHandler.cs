
using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using Lunatic.Application.Features.BookClubs.Payload;
using MediatR;
using Lunatic.Application.Features.BookClubs.Commands.CreatePost;
using Lunatic.Application.Features.Posts.Commands.CreatePost;
using Lunatic.Application.Features.Ratings.Commands.CreateRating;
using Lunatic.Application.Features.Ratings.Mapper;
using Lunatic.Application.Features.BookClubs.Mapper;


namespace Lunatic.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostCommandResponse>
    {
        private readonly IPostRepository postRepository;
        private readonly IUserRepository userRepository;
        private readonly IBookClubRepository bookClubRepository;

        public CreatePostCommandHandler(IPostRepository postRepository, IUserRepository userRepository, IBookClubRepository bookClubRepository)
        {
            this.postRepository = postRepository;
            this.userRepository = userRepository;
            this.bookClubRepository = bookClubRepository;
        }

        public async Task<CreatePostCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePostCommandValidator(this.postRepository, this.userRepository, this.bookClubRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new CreatePostCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            var bookClubResult = await this.bookClubRepository.FindByIdAsync(request.BookClubId);

            var post = new Post(
                 request.UserId,
                 request.BookClubId,
                 request.Text!
             );

            await this.postRepository.AddAsync(post);

            bookClubResult.Value.AddPost(post.PostId);

            var dbBookClubResult = await this.bookClubRepository.UpdateAsync(bookClubResult.Value);

            return new CreatePostCommandResponse
            {
                Success = true,
                Post = new PostDto
                {
                    PostId = post.PostId,
                    UserId = post.UserId,
                    BookClubId = post.BookClubId,
                    CreatedDate = post.CreatedDate,
                    Text = post.Text

                }
            };

        }
    }
}
