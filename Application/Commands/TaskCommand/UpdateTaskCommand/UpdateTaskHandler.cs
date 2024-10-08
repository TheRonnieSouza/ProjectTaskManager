using Application.Models;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.TaskCommand.UpdateTaskCommand
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, ResultViewModel>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public UpdateTaskHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id);

            task.UpdateTask(request.Title,request.Description, request.Priority,request.DeliveryDate,request.UserId, request.ProjectId);
            _context.Update(task);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
