using MediatR;
using EmployeeManagementSystem.DTOs;

namespace EmployeeManagementSystem.Features.Employees.Queries
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto>;
}
