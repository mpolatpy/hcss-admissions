using Application.Core;
using MediatR;
using Persistence;

namespace Application.Applications
{
    public class Detail
    {
        public class Query : IRequest<Result<Domain.Application>>
        {
            public Guid ApplicationId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Domain.Application>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Domain.Application>> Handle(Query request, CancellationToken cancellationToken)
            {
                var application = await _context.Applications.FindAsync(request.ApplicationId);

                return Result<Domain.Application>.Success(application);
            }
        }
    }
}