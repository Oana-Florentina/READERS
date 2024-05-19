using Lunatic.Application.Features.Projects.Commands.CreateProjectTaskSection;
using Lunatic.Application.Features.Projects.Commands.DeleteProjectTaskSection;
using Lunatic.Application.Features.Projects.Queries.GetAllTaskSections;
using Lunatic.Application.Features.Projects.Commands.UpdateProjectTasksSection;
using Microsoft.AspNetCore.Mvc;

namespace Lunatic.API.Controllers {
    public class ProjectsController : ApiControllerBase {
        [HttpGet("{projectId}/tasks/sections")]
        [Produces("application/json")]
        [ProducesResponseType<GetAllProjectTaskSectionsQueryResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<GetAllProjectTaskSectionsQueryResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTaskSections(Guid projectId) {
            var result = await Mediator.Send(new GetAllProjectTaskSectionsQuery(projectId));
            if(!result.Success) {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost("{projectId}/tasks/sections")]
        [Produces("application/json")]
        [ProducesResponseType<CreateProjectTaskSectionCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<CreateProjectTaskSectionCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTaskSection(Guid projectId, CreateProjectTaskSectionCommand command) {
            if(projectId != command.ProjectId) {
                return BadRequest(new CreateProjectTaskSectionCommandResponse {
                    Success = false,
                    ValidationErrors = new List<string> { "The project Id Path and project Id Body must be equal." }
                });
            }

            var result = await Mediator.Send(command);
            if(!result.Success) {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{projectId}/tasks/sections/{section}")]
        [Produces("application/json")]
        [ProducesResponseType<UpdateProjectTasksSectionCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<UpdateProjectTasksSectionCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTaskSection(Guid projectId, string section, UpdateProjectTasksSectionCommand command) {
            if(projectId != command.ProjectId) {
                return BadRequest(new UpdateProjectTasksSectionCommandResponse {
                        Success = false,
                        ValidationErrors = new List<string> { "The project Id Path and project Id Body must be equal." }
                });
            }
            if(section != command.Section) {
                return BadRequest(new UpdateProjectTasksSectionCommandResponse {
                        Success = false,
                        ValidationErrors = new List<string> { "The section Path and section Body must be equal." }
                });
            }

            var result = await Mediator.Send(command);
            if(!result.Success) {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{projectId}/tasks/sections/{section}")]
        [Produces("application/json")]
        [ProducesResponseType<DeleteProjectTaskSectionCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DeleteProjectTaskSectionCommandResponse>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteTaskSection(Guid projectId, string section) {
            var deleteProjectTaskSectionCommand = new DeleteProjectTaskSectionCommand() {
                ProjectId = projectId,
                Section = section
            };
            var result = await Mediator.Send(deleteProjectTaskSectionCommand);
            if(!result.Success) {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

