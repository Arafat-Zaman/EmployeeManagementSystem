using MediatR;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Persistence;
using EmployeeManagementSystem.Features.Employees.Queries;

namespace EmployeeManagementSystem.Features.Employees.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>
    {
        private readonly AppDbContext _context;

        public GetAllEmployeesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FullName = $"{e.FirstName} {e.LastName}",
                    DateOfBirth = e.DateOfBirth,
                    Department = e.Department.Name,
                    Designation = e.Designation.Title
                })
                .ToListAsync(cancellationToken);
        }
    }
}
