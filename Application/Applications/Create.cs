using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Applications
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ApplicationDto Application { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Application).SetValidator(new ApplicationValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var applicant = _mapper.Map<Student>(request.Application);
                var application = _mapper.Map<Domain.Application>(request.Application);
                application.Id = Guid.NewGuid();
                var school = await _context.Schools.FindAsync(request.Application.SchoolId);
                var schoolYear = await _context.SchoolYears.FindAsync(request.Application.SchoolYearId);
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUserName());

                application.School = school;
                application.SchoolYear = schoolYear;
                application.AppUser = user;

                var student = await _context.Students.FirstOrDefaultAsync(x =>
                    x.FirstName.Trim().ToLower() == applicant.FirstName.Trim().ToLower() &&
                    x.LastName.Trim().ToLower() == applicant.LastName.Trim().ToLower() &&
                    x.DOB.Date == applicant.DOB.Date);

                if (student == null)
                {
                    student = applicant;
                    student.Id = Guid.NewGuid();
                    _context.Students.Add(student);
                }
                else
                {
                    var isValid = await CheckApplicationValidity(application, student);
                    if (!isValid) return Result<Unit>.Failure("There is already an application for the student for the grade level, school, and school year");
                }

                student.Applications.Add(application);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Problem creating the application");
            }

            private async Task<bool> CheckApplicationValidity(Domain.Application application, Student student)
            {
                var applicationCheck = await _context.Applications
                    .Where(
                        x => x.Student.Id == student.Id &&
                        x.Grade == application.Grade &&
                        x.SchoolId == application.SchoolId &&
                        x.SchoolYearId == application.SchoolYearId)
                    .FirstOrDefaultAsync();

                return (applicationCheck == null);
            }
        }
    }
}