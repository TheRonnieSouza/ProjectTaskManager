using Application.Models;
using Application.Notification.TaskCreated;
using Core.Repositories;
using MediatR;

namespace Application.Commands.TaskCommand.CreateTaskCommand
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, ResultViewModel<Guid>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        public CreateTaskHandler(ITaskRepository taskRepository, IMediator mediator, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = request.ToEntity();

            await _taskRepository.Add(task);

            var user = await _userRepository.GetDetailsById(task.Id);

            var taskWithProject = await _taskRepository.GetDatailsById(task.Id);

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
