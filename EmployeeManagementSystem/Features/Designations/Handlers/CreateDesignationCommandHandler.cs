using MediatR;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Persistence;
using EmployeeManagementSystem.Features.Designations.Commands;

namespace EmployeeManagementSystem.Features.Designations.Handlers
{
    public class CreateDesignationCommandHandler : IRequestHandler<CreateDesignationCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateDesignationCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDesignationCommand request, CancellationToken cancellationToken)
        {
            var designation = new Designation
            {
                Title = request.Title
            };

            _context.Designations.Add(designation);
            await _context.SaveChangesAsync(cancellationToken);

            return designation.Id;
        }
    }
}
