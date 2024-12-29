using MediatR;

namespace EmployeeManagementSystem.Features.Employees.Commands
{
    public record UpdateEmployeeCommand(
        int Id,
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        int DepartmentId,
        int DesignationId
    ) : IRequest<bool>;
}
