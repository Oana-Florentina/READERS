
using Lunatic.Application.Responses;
using Lunatic.Application.Features.Projects.Payload;


namespace Lunatic.Application.Features.Projects.Commands.UpdateProjectTasksSection {
    public class UpdateProjectTasksSectionCommandResponse : ResponseBase {
        public UpdateProjectTasksSectionCommandResponse() : base() { }

        public ProjectDto Project { get; set; } = default!;
    }
}
