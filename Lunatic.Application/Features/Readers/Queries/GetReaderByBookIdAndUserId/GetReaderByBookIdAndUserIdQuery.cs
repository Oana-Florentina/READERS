﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Readers.Queries.GetReaderByBookIdAndUserId
{
    public class GetReaderByBookIdAndUserIdQuery : IRequest<GetReaderByBookIdAndUserIdQueryResponse>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }

        
    }
}
