using FluentValidation;

namespace Core.Backend.Application.Queries.Example
{
    public class GetExampleByIdQueryValidator : AbstractValidator<GetExampleByIdQuery>
    {
        public GetExampleByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Id).NotNull();
        }
    }
}