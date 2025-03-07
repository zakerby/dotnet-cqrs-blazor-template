using Core.Backend.Application.Models;
using Core.Backend.Domain.Models;
using MediatR;

namespace Core.Backend.Application.Queries.Example
{
    public class GetExampleByIdQuery : IRequest<QueryResult<Domain.Models.Example>>
    {
        public int Id { get; set; }
    }
}