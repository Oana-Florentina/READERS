
using Lunatic.Application.Persistence;
using FluentValidation;


namespace Lunatic.Application.Features.Projects.Commands.DeleteProjectTaskSection {
    internal class DeleteProjectTaskSectionCommandValidator : AbstractValidator<DeleteProjectTaskSectionCommand> {
        private readonly IProjectRepository projectRepository;

        public DeleteProjectTaskSectionCommandValidator(IProjectRepository projectRepository) {
            this.projectRepository = projectRepository;

            RuleFor(request => request.ProjectId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (projectId, cancellationToken) => await this.projectRepository.ExistsByIdAsync(projectId))
                .WithMessage("{PropertyName} must exists.");

            RuleFor(request => request.Section)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(request => new {request.ProjectId, request.Section})
                .MustAsync(async (req, cancellationToken) => {
                        var project = (await this.projectRepository.FindByIdAsync(req.ProjectId)).Value;
                        return project.TaskSections.Contains(req.Section);})
                .WithMessage("Project must include Task Section.");

            ClassLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
