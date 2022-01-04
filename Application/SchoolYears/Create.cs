using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SchoolYears
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public SchoolYear SchoolYear { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.SchoolYear).SetValidator(new SchoolYearValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var schoolYear = await _context.SchoolYears
                                    .FirstOrDefaultAsync(x => x.SchoolYearName == request.SchoolYear.SchoolYearName);

                if(schoolYear != null) return Result<Unit>.Failure("The school year with this name already exists");

                var activeSchoolYear = await _context.SchoolYears.FirstOrDefaultAsync(x => x.IsActiveYear == true);

                if(request.SchoolYear.IsActiveYear && activeSchoolYear != null)
                {
                    activeSchoolYear.IsActiveYear = false;
                }

                _context.SchoolYears.Add(request.SchoolYear);
                
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Result<Unit>.Success(Unit.Value);
                
                return Result<Unit>.Failure("Problem with creating school year");
            }
        }
    }
}