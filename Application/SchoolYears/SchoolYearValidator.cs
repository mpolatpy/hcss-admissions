using Domain;
using FluentValidation;

namespace Application.SchoolYears
{
    public class SchoolYearValidator : AbstractValidator<SchoolYear>
    {
        public SchoolYearValidator()
        {
            RuleFor(x => x.SchoolYearName).NotEmpty();
            RuleFor(x => x.FormLabel).NotEmpty();
            RuleFor(x => x.IsActiveYear).NotNull();
            RuleFor(x => x.DisplayOnForm).NotNull();
        }
    }
}