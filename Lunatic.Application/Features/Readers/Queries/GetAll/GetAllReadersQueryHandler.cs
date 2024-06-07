using Lunatic.Application.Features.Readers.Payload;
using Lunatic.Application.Features.Readers.Queries.GetAll;
using Lunatic.Application.Features.Readers.Mapper;
using Lunatic.Application.Persistence;
using Lunatic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Readers.Queries.GetAll
{
    public class GetAllReadersQueryHandler : IRequestHandler<GetAllReadersQuery, GetAllReadersQueryResponse>
    {
        private readonly IReaderRepository readerRepository;

        public GetAllReadersQueryHandler(IReaderRepository readerRepository)
        {
            this.readerRepository = readerRepository;
        }

        public async Task<GetAllReadersQueryResponse> Handle(GetAllReadersQuery request, CancellationToken cancellationToken)
        {
            GetAllReadersQueryResponse response = new GetAllReadersQueryResponse();
            var readers = await this.readerRepository.GetAllAsync();

            if (readers.IsSuccess)
            {
                response.Readers = readers.Value.Select(reader => ReaderMapper.MapToReaderDto(reader)).ToList();
            }
            return response;
        }
    }
}
