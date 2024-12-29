using MediatR;

namespace EmployeeManagementSystem.Features.Departments.Commands
{
    public record CreateDepartmentCommand(string Name) : IRequest<int>;
}
