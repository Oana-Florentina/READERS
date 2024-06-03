
using Lunatic.Application.Persistence;
using Lunatic.Application.Features.Users.Payload;
using MediatR;
using CloudinaryDotNet.Actions;
using Lunatic.Application.Features.Users.Mapper;


namespace Lunatic.Application.Features.Users.Queries.GetAll {
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersQueryResponse> {
        private readonly IUserRepository userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken) {
            GetAllUsersQueryResponse response = new GetAllUsersQueryResponse();
            var users = await this.userRepository.GetAllAsync();

            if(users.IsSuccess) {

                response.Users = users.Value.Select(user => UserMapper.MapToUserDto(user)).ToList();
            }
            return response;
        }
    }
}
