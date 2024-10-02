using Application.Models;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.TaskCommand.CreateTaskCommand
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, ResultViewModel<Guid>>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public CreateTaskHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = request.ToEntity();

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return ResultViewModel<Guid>.Success(task.Id);
        }
    }
}
