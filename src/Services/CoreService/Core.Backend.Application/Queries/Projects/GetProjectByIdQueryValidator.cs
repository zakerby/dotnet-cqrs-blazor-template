using FluentValidation;

namespace Core.Backend.Application.Queries.Project
{
    public class GetProjectByIdQueryValidator : AbstractValidator<GetProjectByIdQuery>
    {
        public GetProjectByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Id).NotNull();
        }
    }
}