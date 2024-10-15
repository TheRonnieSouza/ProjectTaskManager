using Application.Models;
using Core.Enums;
using Core.Repositories;
using MediatR;

namespace Application.Commands.TaskCommand.AssingTasksToUsersCommand
{
    public class ValidateAssingTaskToUserBehavior : IPipelineBehavior<AssingTasksToUsersCommand, ResultViewModel>
    {
        private readonly ITaskRepository _repository;
        private readonly IUserRepository _userRepository;

        public ValidateAssingTaskToUserBehavior(ITaskRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(AssingTasksToUsersCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var task = await _repository.GetById(request.TaskId);

            if (task == null)
                return ResultViewModel.Error("Task not found.");

            var userExist = await _userRepository.Exist(request.UserId);

            if (!userExist)
                return ResultViewModel.Error("User not found.");

            var user = await _userRepository.GetById(request.UserId);

            if(user.Profile != Profile.Operator)
                return ResultViewModel.Error("The user need to be a Operator.");

            return await next();
        }
    }
}
