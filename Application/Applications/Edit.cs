using Application.Core;
using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Applications
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ApplicationDto Application { get; set; }
            public Guid ApplicationId { get; set; }
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
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var application = await _context.Applications.FindAsync(request.ApplicationId);
                
                if(application == null) return null;

                _mapper.Map(request.Application, application);

                var result = await _context.SaveChangesAsync() > 0;

                if(!result) return Result<Unit>.Failure("Failed to update the application");
                
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}