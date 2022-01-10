using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Schools
{
    public class Detail
    {
        public class Query : IRequest<Result<School>>
        {
            public int SchoolId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<School>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<School>> Handle(Query request, CancellationToken cancellationToken)
            {
                var school = await _context.Schools.FindAsync(request.SchoolId);

                return Result<School>.Success(school);
            }
        }
    }
}