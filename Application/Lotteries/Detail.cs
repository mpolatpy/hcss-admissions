using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Lotteries
{
    public class Detail
    {
        public class Query : IRequest<Result<WaitList>>
        {
            public int LotteryId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<WaitList>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<WaitList>> Handle(Query request, CancellationToken cancellationToken)
            {
                var waitList = await _context.WaitLists
                    .Include(x => x.School)
                    .Include(x => x.SchoolYear)
                    .FirstOrDefaultAsync(x => x.Id == request.LotteryId);

                return Result<WaitList>.Success(waitList);
            }
        }
    }
}