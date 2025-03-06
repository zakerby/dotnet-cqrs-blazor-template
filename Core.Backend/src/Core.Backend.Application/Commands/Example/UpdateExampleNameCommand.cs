using Core.Backend.Application.Models;
using MediatR;

namespace Core.Backend.Application.Commands.Example
{
    public class UpdateExampleNameCommand : IRequest<CommandResult<bool>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}