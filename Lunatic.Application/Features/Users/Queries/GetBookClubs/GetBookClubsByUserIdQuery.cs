using MediatR;


namespace Lunatic.Application.Features.Users.Queries.GetBookClubs
{
    public record GetBookClubsByUserIdQuery(Guid UserId) : IRequest<GetBookClubsByUserIdQueryResponse>;
}
