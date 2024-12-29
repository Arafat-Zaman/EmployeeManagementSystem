using MediatR;
using EmployeeManagementSystem.Persistence;
using EmployeeManagementSystem.Features.Employees.Commands;

namespace EmployeeManagementSystem.Features.Employees.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateEmployeeCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(new object[] { request.Id }, cancellationToken);
            if (employee == null) return false;

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.DateOfBirth = request.DateOfBirth;
            employee.DepartmentId = request.DepartmentId;
            employee.DesignationId = request.DesignationId;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
