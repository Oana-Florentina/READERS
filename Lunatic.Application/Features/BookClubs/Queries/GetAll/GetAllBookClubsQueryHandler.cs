using Lunatic.Application.Features.BookClubs.Payload;
using Lunatic.Application.Features.BookClubs.Queries.GetAll;
using Lunatic.Application.Features.BookClubs.Mapper;
using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.BookClubs.Queries.GetAll
{
    public class GetAllBookClubsQueryHandler : IRequestHandler<GetAllBookClubsQuery, GetAllBookClubsQueryResponse>
    {
        private readonly IBookClubRepository bookClubRepository;

        public GetAllBookClubsQueryHandler(IBookClubRepository bookClubRepository)
        {
            this.bookClubRepository = bookClubRepository;
        }

        public async Task<GetAllBookClubsQueryResponse> Handle(GetAllBookClubsQuery request, CancellationToken cancellationToken)
        {
            GetAllBookClubsQueryResponse response = new GetAllBookClubsQueryResponse();
            var bookClubs = await this.bookClubRepository.GetAllAsync();

            if (bookClubs.IsSuccess)
            {
                response.BookClubs = bookClubs.Value.Select(bookClub => BookClubMapper.MapToBookClubDto(bookClub)).ToList();
            }
            return response;
        }
    }
}
