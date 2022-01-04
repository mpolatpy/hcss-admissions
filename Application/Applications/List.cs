using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Applications
{
    public class List
    {
        public class Query : IRequest<Result<List<Domain.Application>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<Domain.Application>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Domain.Application>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var applications = await _context.Applications
                    .Include(a => a.SchoolYear)
                    .Include(a => a.School)
                    .ToListAsync();

                return Result<List<Domain.Application>>.Success(applications);
            }
        }
    }
}