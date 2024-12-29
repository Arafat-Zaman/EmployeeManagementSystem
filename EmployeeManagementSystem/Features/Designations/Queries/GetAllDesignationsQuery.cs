using MediatR;
using System.Collections.Generic;
using EmployeeManagementSystem.DTOs;

namespace EmployeeManagementSystem.Features.Designations.Queries
{
    public record GetAllDesignationsQuery : IRequest<List<DesignationDto>>;
}
