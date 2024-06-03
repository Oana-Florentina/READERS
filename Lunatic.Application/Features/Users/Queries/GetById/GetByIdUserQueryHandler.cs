
using Lunatic.Application.Persistence;
using Lunatic.Application.Features.Users.Payload;
using MediatR;
using Lunatic.Application.Features.Users.Mapper;


namespace Lunatic.Application.Features.Users.Queries.GetById {
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserQueryResponse> {
        private readonly IUserRepository userRepository;

        public GetByIdUserQueryHandler(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken) {
            var userResult = await this.userRepository.FindByIdAsync(request.UserId);
            if(!userResult.IsSuccess) {
                return new GetByIdUserQueryResponse {
                    Success = false,
                    ValidationErrors = new List<string> { "User not found" }
                };
            }

            return new GetByIdUserQueryResponse { 
                Success = true,
                User = UserMapper.MapToUserDto(userResult.Value)
            };
        }
    }
}
