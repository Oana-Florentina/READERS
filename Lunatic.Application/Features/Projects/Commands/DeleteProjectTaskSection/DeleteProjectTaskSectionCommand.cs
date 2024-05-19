
using MediatR;


namespace Lunatic.Application.Features.Projects.Commands.DeleteProjectTaskSection {
    public class DeleteProjectTaskSectionCommand : IRequest<DeleteProjectTaskSectionCommandResponse> {
        public Guid ProjectId { get; set; } = default!;

        public string Section { get; set; } = default!;
    }
}
