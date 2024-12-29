using MediatR;

namespace EmployeeManagementSystem.Features.Employees.Commands
{
    public record CreateEmployeeCommand(
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        int DepartmentId,
        int DesignationId
    ) : IRequest<int>;
}
