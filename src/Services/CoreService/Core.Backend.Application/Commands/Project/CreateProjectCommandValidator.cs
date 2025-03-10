using FluentValidation;

namespace Core.Backend.Application.Commands.Project
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Project.Name).NotEmpty();
            RuleFor(x => x.Project.Name).NotNull();
        }
    }
}