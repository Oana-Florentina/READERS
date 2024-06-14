using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Features.Cover.Payload
{
    public class CoverDto
    {
        public Guid CoverId { get; set; } = default!;
        public string Url { get; set; } = default!;
    }
}
