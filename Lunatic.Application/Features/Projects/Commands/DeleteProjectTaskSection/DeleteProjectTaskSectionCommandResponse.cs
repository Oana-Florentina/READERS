
using Lunatic.Application.Responses;
using Lunatic.Application.Features.Projects.Payload;


namespace Lunatic.Application.Features.Projects.Commands.DeleteProjectTaskSection {
    public class DeleteProjectTaskSectionCommandResponse : ResponseBase {
        public DeleteProjectTaskSectionCommandResponse() : base() { }

        public ProjectDto Project { get; set; } = default!;
    }
}

