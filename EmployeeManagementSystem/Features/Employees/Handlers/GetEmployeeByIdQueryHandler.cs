using MediatR;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Persistence;
using EmployeeManagementSystem.Features.Employees.Queries;

namespace EmployeeManagementSystem.Features.Employees.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly AppDbContext _context;

        public GetEmployeeByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (employee == null) return null;

            return new EmployeeDto
            {
                Id = employee.Id,
                FullName = $"{employee.FirstName} {employee.LastName}",
                DateOfBirth = employee.DateOfBirth,
                Department = employee.Department.Name,
                Designation = employee.Designation.Title
            };
        }
    }
}
