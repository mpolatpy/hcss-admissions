using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SchoolYears
{
    public class Detail
    {
        public class Query : IRequest<Result<SchoolYear>>
        {
            public string SchoolYearName { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<SchoolYear>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<SchoolYear>> Handle(Query request, CancellationToken cancellationToken)
            {
                var schoolYear = await _context.SchoolYears.FirstOrDefaultAsync(x => x.SchoolYearName == request.SchoolYearName);

                return Result<SchoolYear>.Success(schoolYear);
            }
        }
    }
}