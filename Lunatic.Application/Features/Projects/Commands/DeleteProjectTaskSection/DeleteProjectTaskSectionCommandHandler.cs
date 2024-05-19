
using Lunatic.Application.Persistence;
using Lunatic.Application.Features.Projects.Payload;
using MediatR;


namespace Lunatic.Application.Features.Projects.Commands.DeleteProjectTaskSection {
    public class DeleteProjectTaskSectionCommandHandler : IRequestHandler<DeleteProjectTaskSectionCommand, DeleteProjectTaskSectionCommandResponse> {
        private readonly IProjectRepository projectRepository;

        // private readonly ITaskRepository taskRepository;

        // public DeleteProjectTaskSectionCommandHandler(IProjectRepository projectRepository, ITaskRepository taskRepository) {
        public DeleteProjectTaskSectionCommandHandler(IProjectRepository projectRepository) {
            this.projectRepository = projectRepository;
            // this.taskRepository = taskRepository;
        }

        public async Task<DeleteProjectTaskSectionCommandResponse> Handle(DeleteProjectTaskSectionCommand request, CancellationToken cancellationToken) {
            var validator = new DeleteProjectTaskSectionCommandValidator(this.projectRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validatorResult.IsValid) {
                return new DeleteProjectTaskSectionCommandResponse {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var project = (await this.projectRepository.FindByIdAsync(request.ProjectId)).Value;
            project.RemoveTaskSection(request.Section);
            var dbProjectResult = await this.projectRepository.UpdateAsync(project);

            // var tasks = (await this.taskRepository.GetAllAsync()).Value;
            // foreach (var task in tasks) {
            //     if(task.Section == request.Section) {
            //         await this.taskRepository.DeleteAsync(task.TaskId);
            //     }
            // }

            return new DeleteProjectTaskSectionCommandResponse {
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
