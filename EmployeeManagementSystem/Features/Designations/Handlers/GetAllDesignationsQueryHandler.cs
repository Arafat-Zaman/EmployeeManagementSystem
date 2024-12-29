using MediatR;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagementSystem.Features.Designations.Queries;

namespace EmployeeManagementSystem.Features.Designations.Handlers
{
    public class GetAllDesignationsQueryHandler : IRequestHandler<GetAllDesignationsQuery, List<DesignationDto>>
    {
        private readonly AppDbContext _context;

        public GetAllDesignationsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DesignationDto>> Handle(GetAllDesignationsQuery request, CancellationToken cancellationToken)
        {
            return _context.Designations
                .Select(d => new DesignationDto
                {
                    Id = d.Id,
                    Title = d.Title
                })
                .ToList();
        }
    }
}
