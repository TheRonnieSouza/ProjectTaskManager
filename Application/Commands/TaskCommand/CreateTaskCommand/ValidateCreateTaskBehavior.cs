using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.TaskCommand.CreateTaskCommand
{
    public class ValidateCreateTaskBehavior : IPipelineBehavior<CreateTaskCommand, ResultViewModel<Guid>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;

        public ValidateCreateTaskBehavior(ITaskRepository taskRepository, IProjectRepository projectRepository)
        {
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
        }
        public async Task<ResultViewModel<Guid>> Handle(CreateTaskCommand request, RequestHandlerDelegate<ResultViewModel<Guid>> next, CancellationToken cancellationToken)
        {
            var projectExist = await _projectRepository.Exist(request.ProjectId);

            if (!projectExist)
                return ResultViewModel<Guid>.Error("The project for this task, does not exist.");

            var allTask = await _taskRepository.GetAll();

            var taskName = allTask.Any(t => t.Title == request.Title && t.ProjectId == request.ProjectId);

            if (taskName)
                return ResultViewModel<Guid>.Error("The task already exist.");

            return await next();
        }
    }
}
