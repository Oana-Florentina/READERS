
using MediatR;


namespace Lunatic.Application.Features.Books.Queries.GetById
{
    public record GetByIdBookQuery(Guid BookId) : IRequest<GetByIdBookQueryResponse>;
}

