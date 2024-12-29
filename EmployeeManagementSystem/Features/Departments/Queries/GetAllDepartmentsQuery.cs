using MediatR;
using System.Collections.Generic;
using EmployeeManagementSystem.DTOs;

namespace EmployeeManagementSystem.Features.Departments.Queries
{
    public record GetAllDepartmentsQuery : IRequest<List<DepartmentDto>>;
}
