using MediatR;

namespace EmployeeManagementSystem.Features.Designations.Commands
{
    public record CreateDesignationCommand(string Title) : IRequest<int>;
}
