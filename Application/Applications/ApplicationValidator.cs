using FluentValidation;

namespace Application.Applications
{
    public class ApplicationValidator : AbstractValidator<ApplicationDto>
    {
        public ApplicationValidator()
        {
            // application details
            RuleFor(x => x.SchoolId).NotEmpty();
            RuleFor(x => x.SchoolYearId).NotEmpty();
            RuleFor(x => x.Grade).NotEmpty();
            // applicant
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DOB).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.CurrentGrade).NotEmpty();
            RuleFor(x => x.CurrentSchool).NotEmpty();
            RuleFor(x => x.HasSibling).NotNull();
            // address
            RuleFor(x => x.StreetAddress).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.Zipcode).NotEmpty();
            // parent
            RuleFor(x => x.PrimaryParentName).NotEmpty();
            RuleFor(x => x.PrimaryParentRelationship).NotEmpty();
            RuleFor(x => x.PrimaryParentEmail).NotEmpty().EmailAddress();
            RuleFor(x => x.PrimaryParentPhoneNumber).NotEmpty();
            // other details
            RuleFor(x => x.AgreeToTerms).NotEmpty();
        }
    }
}