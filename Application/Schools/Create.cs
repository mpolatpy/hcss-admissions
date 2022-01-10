using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Schools
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public School School { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.School).SetValidator(new SchoolValidator());
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
                var school = await _context.Schools.FirstOrDefaultAsync(x => x.SchoolName == request.School.SchoolName);

                if(school != null) return Result<Unit>.Failure("There is already a school with this name");

                _context.Schools.Add(new School
                {
                    SchoolName = request.School.SchoolName
                });

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Problem adding school to the database");
            }
        }
    }
}