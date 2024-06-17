using Lunatic.Application.Persistence;
using MediatR;
using Lunatic.Application.Features.Users.Mapper;
using Lunatic.Application.Features.Users.Payload;
using Lunatic.Application.Features.Users.Queries.GetFriendRecommandationByReceiverId;

namespace Lunatic.Application.Features.FriendRecommandations.Queries.GetById
{
    public class GetFriendRecommandationByReceiverIdQueryHandler : IRequestHandler<GetFriendRecommandationByReceiverIdQuery, GetFriendRecommandationByReceiverIdQueryResponse>
    {
        private readonly IFriendRecommandationRepository friendRecommandationRepository;
        private readonly IUserRepository userRepository;

        public GetFriendRecommandationByReceiverIdQueryHandler(IFriendRecommandationRepository friendRecommandationRepository, IUserRepository userRepository)
        {
            this.friendRecommandationRepository = friendRecommandationRepository;
            this.userRepository = userRepository;
        }

        public async Task<GetFriendRecommandationByReceiverIdQueryResponse> Handle(GetFriendRecommandationByReceiverIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetFriendRecommandationByReceiverIdQueryResponse();

            var userResult = await this.userRepository.FindByIdAsync(request.ReceiverId);

            if (!userResult.IsSuccess || userResult.Value == null)
            {
                return new GetFriendRecommandationByReceiverIdQueryResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { "User not found" }
                };
            }
            var friendRecommandationResult = await this.friendRecommandationRepository.GetFriendRecommandationsByReceiverIdAsync(request.ReceiverId);
          
            if (friendRecommandationResult == null || !friendRecommandationResult.IsSuccess)
            {
               return new GetFriendRecommandationByReceiverIdQueryResponse
                {
                    Success = true,
                    FriendRecommandations = new List<FriendRecommandationDto>()
                };
            }
            

            response.Success = true;
            response.FriendRecommandations = friendRecommandationResult.Value
                .Select(FriendRecommandationMapper.MapToFriendRecommandationDto)
                .ToList();

            return response;
        }
    }
}
