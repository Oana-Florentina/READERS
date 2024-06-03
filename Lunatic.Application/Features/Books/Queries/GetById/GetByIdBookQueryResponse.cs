
using Lunatic.Application.Responses;
using Lunatic.Application.Features.Books.Payload;


namespace Lunatic.Application.Features.Books.Queries.GetById
{
    public class GetByIdBookQueryResponse : ResponseBase
    {
        public GetByIdBookQueryResponse() : base() { }

        public BookDto Book { get; set; } = default!;
    }
}

