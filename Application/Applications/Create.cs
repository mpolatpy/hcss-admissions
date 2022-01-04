using Application.Core;
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
            public Domain.Application Application { get; set; }
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
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var schoolYear = await _context.SchoolYears
                    .FirstOrDefaultAsync(x => x.Id == request.Application.SchoolYearId);
                if(schoolYear == null) return null;

                var school = await _context.Schools
                    .FirstOrDefaultAsync(x => x.Id == request.Application.SchoolId );
                if(school == null) return null;

                var lottery = await _context.Lotteries
                    .FirstOrDefaultAsync(x => x.SchoolYearId == request.Application.SchoolYearId 
                        && x.SchoolID == request.Application.SchoolId && x.Grade == request.Application.Grade);

                if(lottery == null){
                    lottery = new Lottery
                    {
                        School = school,
                        SchoolYear = schoolYear,
                        Grade = request.Application.Grade
                    };

                    schoolYear.Lotteries.Add(lottery);
                }

                request.Application.SchoolYear = schoolYear;
                request.Application.School = school;
                request.Application.Lottery = lottery;

                _context.Applications.Add(request.Application);

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Problem adding the application");
            }
        }
    }
}