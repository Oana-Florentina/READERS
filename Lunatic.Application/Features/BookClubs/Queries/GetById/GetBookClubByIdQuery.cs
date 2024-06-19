using MediatR;

namespace Lunatic.Application.Features.BookClubs.Queries.GetById
{
    public record GetBookClubByIdQuery(Guid BookClubId) : IRequest<GetBookClubByIdQueryResponse>;
}
