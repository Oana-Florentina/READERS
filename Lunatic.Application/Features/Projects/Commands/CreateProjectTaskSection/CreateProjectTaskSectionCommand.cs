
using MediatR;


namespace Lunatic.Application.Features.Projects.Commands.CreateProjectTaskSection {
    public class CreateProjectTaskSectionCommand : IRequest<CreateProjectTaskSectionCommandResponse> {
        public Guid ProjectId { get; set; } = default!;

        public string Section { get; set; } = default!;
    }
}
