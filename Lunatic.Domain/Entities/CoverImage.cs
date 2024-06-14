using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Domain.Entities
{
    public class CoverImage
    {
        public CoverImage(string url)
        {
            CoverImageId = Guid.NewGuid();
            Url = url;
            CreatedDate = DateTime.UtcNow;
        }
        public Guid CoverImageId { get; private set; }
        public string Url { get; private set; }
        public DateTime CreatedDate { get; private set; }
    }
}
