using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Serilog;
using Asp.Versioning;

using Core.Backend.Application.Models;
using Core.Backend.Domain.Models;
using Core.Backend.Application.Queries.Projects;

namespace Core.Backend.Api.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public ProjectController(
            ILogger logger,
            IMediator mediator
        )
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get an Project by it's ID
        /// </summary>
        /// <remarks>
        /// Retrieves an Project by the ID specified
        /// </remarks>
        /// <param name="id">ID of the project</param>
        [HttpGet]
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("projects/{id}")]
        public async Task<ActionResult<Project>> GetProjectById([FromRoute] int id)
        {
            var getProjectByIdQuery = new GetProjectByIdQuery()
            {
                Id = id,
            };

            var result = await _mediator.Send(getProjectByIdQuery);

            if (result.Type == QueryResultTypeEnum.InvalidInput)
            {
                return new BadRequestResult();
            }

            if (result.Type == QueryResultTypeEnum.NotFound)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(result.Result);
        }

    }
}