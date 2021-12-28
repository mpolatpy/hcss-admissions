using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Students
{
    public class Details
    {
        public class Query : IRequest<Result<StudentDto>>
        {
            public Guid StudentId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<StudentDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<StudentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var student = await _context.Students
                    .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.StudentId == request.StudentId);

                return Result<StudentDto>.Success(student);
            }
        }
    }
}