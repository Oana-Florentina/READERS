using Lunatic.Application.Persistence;
using MediatR;
using Lunatic.Application.Features.Users.Mapper;
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
            var friendRecommandationResult = await this.friendRecommandationRepository.GetFriendRecommandationsByReceiverIdAsync(request.ReceiverId);

            if (!friendRecommandationResult.IsSuccess)
            {
                response.Success = false;
                response.ValidationErrors.Add("FriendRecommandation not found");
                return response;
            }

            response.Success = true;
            response.FriendRecommandations = friendRecommandationResult.Value
                .Select(FriendRecommandationMapper.MapToFriendRecommandationDto)
                .ToList();

            return response;
        }
    }
}
