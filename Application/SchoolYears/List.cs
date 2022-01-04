using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SchoolYears
{
    public class List
    {
        public class Query : IRequest<Result<List<SchoolYear>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<SchoolYear>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<SchoolYear>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var schoolYears = await _context.SchoolYears.ToListAsync();

                return Result<List<SchoolYear>>.Success(schoolYears);
            }
        }
    }
}