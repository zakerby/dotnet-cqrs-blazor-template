using MediatR;

using Core.Backend.Application.Models;

namespace Core.Backend.Application.Queries.Project
{
    public class GetProjectByIdQuery : IRequest<QueryResult<Domain.Models.Project>>
    {
        public int Id { get; set; }
    }
}