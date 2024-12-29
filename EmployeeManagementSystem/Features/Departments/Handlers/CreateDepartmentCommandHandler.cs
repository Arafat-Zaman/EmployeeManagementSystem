using MediatR;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Persistence;
using EmployeeManagementSystem.Features.Departments.Commands;

namespace EmployeeManagementSystem.Features.Departments.Handlers
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateDepartmentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department
            {
                Name = request.Name
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync(cancellationToken);

            return department.Id;
        }
    }
}
