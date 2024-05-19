
using MediatR;


namespace Lunatic.Application.Features.Projects.Commands.UpdateProjectTasksSection {
    public class UpdateProjectTasksSectionCommand : IRequest<UpdateProjectTasksSectionCommandResponse> {
        public Guid ProjectId { get; set; } = default!;

        public string Section { get; set; } = default!;
        public string NewSection { get; set; } = default!;
    }
}
