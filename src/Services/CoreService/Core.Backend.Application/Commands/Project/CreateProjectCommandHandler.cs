using System.Threading;
using System.Threading.Tasks;
using Core.Backend.Application.Interfaces;
using Core.Backend.Application.Models;
using FluentValidation;
using MediatR;
using Serilog;

namespace Core.Backend.Application.Commands.Project 
{

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CommandResult<bool>>
    {
        private readonly IValidator<CreateProjectCommand> _validator;
        private readonly ILogger _logger;

        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandHandler(
            ILogger logger,
            IProjectRepository projectRepository,
            IValidator<CreateProjectCommand> validator)
        {
            _logger = logger;
            _projectRepository = projectRepository;
            _validator = validator;
        }

        public async Task<CommandResult<bool>> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(command);

            if (!validation.IsValid)
            {
                _logger.Error("Create project command produced errors on validation {Errors}", validation.ToString());
                return new CommandResult<bool>(result: false, type: CommandResultTypeEnum.InvalidInput);
            }
            var rowCreated = await _projectRepository.CreateProject(command.Project.Name);

            if (!rowCreated)
            {
                return new CommandResult<bool>(result: false, type: CommandResultTypeEnum.NotFound);
            }
            return new CommandResult<bool>(result: true, type: CommandResultTypeEnum.Success);
        }
    }
}