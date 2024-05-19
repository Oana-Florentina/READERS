
using Lunatic.Application.Persistence;
using Lunatic.Application.Features.Projects.Payload;
using MediatR;


namespace Lunatic.Application.Features.Projects.Commands.UpdateProjectTasksSection {
    public class UpdateProjectTasksSectionCommandHandler : IRequestHandler<UpdateProjectTasksSectionCommand, UpdateProjectTasksSectionCommandResponse> {
        // private readonly ITaskRepository taskRepository;

        private readonly IProjectRepository projectRepository;

        // public UpdateProjectTasksSectionCommandHandler(ITaskRepository taskRepository, IProjectRepository projectRepository) {
        public UpdateProjectTasksSectionCommandHandler(IProjectRepository projectRepository) {
            // this.taskRepository = taskRepository;
            this.projectRepository = projectRepository;
        }

        public async Task<UpdateProjectTasksSectionCommandResponse> Handle(UpdateProjectTasksSectionCommand request, CancellationToken cancellationToken) {
            var validator = new UpdateProjectTasksSectionCommandValidator(this.projectRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validatorResult.IsValid) {
                return new UpdateProjectTasksSectionCommandResponse {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var projectResult = await this.projectRepository.FindByIdAsync(request.ProjectId);

            // var tasks = (await this.taskRepository.GetAllAsync()).Value;
            // foreach (var task in tasks) {
            //     if(task.Section == request.Section) {
            //         task.SetSection(request.NewSection);
            //         await this.taskRepository.UpdateAsync(task);
            //     }
            // }

            projectResult.Value.RemoveTaskSection(request.Section);
            projectResult.Value.AddTaskSection(request.NewSection);

            var dbProjectResult = await this.projectRepository.UpdateAsync(projectResult.Value);

            return new UpdateProjectTasksSectionCommandResponse {
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
