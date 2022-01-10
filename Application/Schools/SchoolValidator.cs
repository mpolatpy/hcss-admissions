using Domain;
using FluentValidation;

namespace Application.Schools
{
    public class SchoolValidator : AbstractValidator<School>
    {
        public SchoolValidator()
        {
            RuleFor(x => x.SchoolName).NotEmpty();
        }
    }
}