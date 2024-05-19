
using Lunatic.Application.Persistence;
using Lunatic.Application.Features.Projects.Payload;
using MediatR;


namespace Lunatic.Application.Features.Projects.Commands.CreateProjectTaskSection {
    public class CreateProjectTaskSectionCommandHandler : IRequestHandler<CreateProjectTaskSectionCommand, CreateProjectTaskSectionCommandResponse> {
        private readonly IProjectRepository projectRepository;

        public CreateProjectTaskSectionCommandHandler(IProjectRepository projectRepository) {
            this.projectRepository = projectRepository;
        }

        public async Task<CreateProjectTaskSectionCommandResponse> Handle(CreateProjectTaskSectionCommand request, CancellationToken cancellationToken) {
            var validator = new CreateProjectTaskSectionCommandValidator(this.projectRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validatorResult.IsValid) {
                return new CreateProjectTaskSectionCommandResponse {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var project = (await this.projectRepository.FindByIdAsync(request.ProjectId)).Value;
            project.AddTaskSection(request.Section);
            var dbProjectResult = await this.projectRepository.UpdateAsync(project);

            return new CreateProjectTaskSectionCommandResponse {
                Success = true,
                Project = new ProjectDto {
                    CreatedByUserId = dbProjectResult.Value.CreatedByUserId,
                    ProjectId = dbProjectResult.Value.ProjectId,
                    TeamId = dbProjectResult.Value.TeamId,

                    Title = dbProjectResult.Value.Title,
                    Description = dbProjectResult.Value.Description,

                    TaskSections = dbProjectResult.Value.TaskSections,
                    // TaskIds = dbProjectResult.Value.TaskIds,
                }
            };
        }
    }
}
