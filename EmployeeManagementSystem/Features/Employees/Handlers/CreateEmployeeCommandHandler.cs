using MediatR;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Persistence;
using EmployeeManagementSystem.Features.Employees.Commands;

namespace EmployeeManagementSystem.Features.Employees.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateEmployeeCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                DepartmentId = request.DepartmentId,
                DesignationId = request.DesignationId
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}
