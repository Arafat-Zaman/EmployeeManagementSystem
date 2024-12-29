using MediatR;
using System.Collections.Generic;
using EmployeeManagementSystem.DTOs;

namespace EmployeeManagementSystem.Features.Employees.Queries
{
    public record GetAllEmployeesQuery : IRequest<List<EmployeeDto>>;
}
