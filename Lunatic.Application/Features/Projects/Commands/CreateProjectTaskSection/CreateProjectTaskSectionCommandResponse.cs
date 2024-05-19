
using Lunatic.Application.Responses;
using Lunatic.Application.Features.Projects.Payload;


namespace Lunatic.Application.Features.Projects.Commands.CreateProjectTaskSection {
    public class CreateProjectTaskSectionCommandResponse : ResponseBase {
        public CreateProjectTaskSectionCommandResponse() : base() { }

        public ProjectDto Project { get; set; } = default!;
    }
}

