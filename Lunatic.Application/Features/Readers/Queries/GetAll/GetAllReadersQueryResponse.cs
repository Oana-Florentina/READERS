using Lunatic.Application.Features.Readers.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Readers.Queries.GetAll
{
    public class GetAllReadersQueryResponse
    {
        public List<ReaderDto> Readers { get; set; } = default!;
    }
}
