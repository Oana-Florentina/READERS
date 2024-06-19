using Lunatic.Application.Features.Books.Queries.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.BookClubs.Queries.GetAll
{
    public class GetAllBookClubsQuery : IRequest<GetAllBookClubsQueryResponse>
    {
    }
}
