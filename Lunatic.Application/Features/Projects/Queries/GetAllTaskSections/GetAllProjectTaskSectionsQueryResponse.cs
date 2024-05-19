
using Lunatic.Application.Responses;


namespace Lunatic.Application.Features.Projects.Queries.GetAllTaskSections {
    public class GetAllProjectTaskSectionsQueryResponse : ResponseBase {
        public GetAllProjectTaskSectionsQueryResponse() : base() {}

        public List<string> Sections { get; set; } = default!;
    }
}
