using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Lotteries
{
    public class List
    {
        public class Query : IRequest<Result<List<WaitList>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<WaitList>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<WaitList>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var waitLists = await _context.WaitLists.ToListAsync();

                return Result<List<WaitList>>.Success(waitLists);
            }
        }
    }
}