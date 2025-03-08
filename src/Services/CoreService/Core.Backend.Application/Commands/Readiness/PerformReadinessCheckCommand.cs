using Core.Backend.Application.Models;
using MediatR;

namespace Core.Backend.Application.Commands.Readiness
{
    public class PerformReadinessCheckCommand : IRequest<CommandResult<string>>
    {
    }
}
