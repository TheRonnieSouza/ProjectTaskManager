using Application.Models;
using Application.Notification.TaskCreated;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.TaskCommand.CreateTaskCommand
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, ResultViewModel<Guid>>
    {
        private readonly ProjectTaskManagerDbContext _context;
        private readonly IMediator _mediator;
        public CreateTaskHandler(ProjectTaskManagerDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = request.ToEntity();

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            var user = await _context.Users
                                     .Include(u => u.ParticipaitingProjects) 
                                     .FirstOrDefaultAsync(u => u.Id == task.UserId);

            var taskWithProject = await _context.Tasks
                                                .Include(t => t.Project) 
                                                .FirstOrDefaultAsync(t => t.Id == task.Id);

            if (user == null || taskWithProject == null)
            {
                return ResultViewModel<Guid>.Error("Error in the notification, User or Task not found.");
            }

            var createdNotification = new TaskCreatedNotification(
                taskWithProject.Id,
                user.Id,
                taskWithProject.ProjectId,
                taskWithProject.Title,
                taskWithProject.Project.Name,
                user.Name 
            );

            _mediator.Publish(createdNotification);
            return ResultViewModel<Guid>.Success(task.Id);
        }
    }
}
