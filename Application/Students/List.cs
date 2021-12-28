using System.Collections.Generic;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Students
{
    public class List
    {
        public class Query : IRequest<Result<List<StudentDto>>>
        {
            
        }

        public class Handler : IRequestHandler<Query, Result<List<StudentDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<StudentDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var students = await _context.Students
                    .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return Result<List<StudentDto>>.Success(students);
            }
        }
    }
}