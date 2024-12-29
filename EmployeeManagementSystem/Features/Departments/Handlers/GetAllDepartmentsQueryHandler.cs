using MediatR;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagementSystem.Features.Departments.Queries;

namespace EmployeeManagementSystem.Features.Departments.Handlers
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<DepartmentDto>>
    {
        private readonly AppDbContext _context;

        public GetAllDepartmentsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return _context.Departments
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToList();
        }
    }
}
