using System.Threading;
using System.Threading.Tasks;
using Core.Backend.Application.Interfaces;
using Core.Backend.Application.Models;
using Core.Backend.Domain.Models;
using MediatR;
using FluentValidation;
using Serilog;

namespace Core.Backend.Application.Queries.Example
{
    public class GetExampleByIdQueryHandler : IRequestHandler<GetExampleByIdQuery, QueryResult<Domain.Models.Example>>
    {
        private readonly IValidator<GetExampleByIdQuery> _validator;
        private readonly IExampleServiceClient _exampleServiceClient;
        private readonly ILogger _logger;

        public GetExampleByIdQueryHandler(
            ILogger logger,
            IExampleServiceClient exampleRepository,
            IValidator<GetExampleByIdQuery> validator)
        {
            _logger = logger;
            _exampleServiceClient = exampleRepository;
            _validator = validator;
        }

        public async Task<QueryResult<Domain.Models.Example>> Handle(GetExampleByIdQuery request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                _logger.Error("Get example by id with id {Id} produced errors on validation {Errors}", request.Id, validation.ToString());
                return new QueryResult<Domain.Models.Example>(result: default(Domain.Models.Example), type: QueryResultTypeEnum.InvalidInput);
            }
            var example = await _exampleServiceClient.GetExampleById(request.Id);

            if (example == null)
            {
                return new QueryResult<Domain.Models.Example>(result: example, type: QueryResultTypeEnum.NotFound);
            }
            return new QueryResult<Domain.Models.Example>(result: example, type: QueryResultTypeEnum.Success);
        }
    }
}