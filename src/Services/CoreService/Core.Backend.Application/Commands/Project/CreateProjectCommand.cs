using Core.Backend.Application.Models;
using MediatR;
using Core.Backend.Domain.Models;

using Core.Backend.Application.Models.Project;

namespace Core.Backend.Application.Commands.Project 
{
    public class CreateProjectCommand : IRequest<CommandResult<bool>>
    {
        public CreateProjectBodyDto Project { get; set; }
    }
}