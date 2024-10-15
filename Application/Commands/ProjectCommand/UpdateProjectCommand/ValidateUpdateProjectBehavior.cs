using Application.Models;
using Core.Enums;
using Core.Repositories;
using MediatR;

namespace Application.Commands.ProjectCommand.UpdateProjectCommand
{
    public class ValidateUpdateProjectBehavior :IPipelineBehavior<UpdateProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;  
        public ValidateUpdateProjectBehavior(IProjectRepository projectRepository,IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateProjectCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.Id);

            if (project == null)
                return ResultViewModel.Error("Project not found.");

            var ProfileExist = await _userRepository.ProfileExist(request.ParticipatingId, Profile.Operator);

            if (!ProfileExist)
                return ResultViewModel.Error("The Operator to be up to date was not found.");

            ProfileExist = await _userRepository.ProfileExist(request.ParticipatingId, Profile.Manager); 

            if (!ProfileExist)
                return ResultViewModel.Error("The Manager to be up to date was not found.");

            return await next();
        }
    }
}
