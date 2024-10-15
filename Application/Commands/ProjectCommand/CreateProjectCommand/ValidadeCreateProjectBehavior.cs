using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.ProjectCommand.CreateProjectCommand
{
    public class ValidadeCreateProjectBehavior : IPipelineBehavior<CreateProjectCommand, ResultViewModel<Guid>>
    {
        private readonly IProjectRepository _repository;
        public ValidadeCreateProjectBehavior(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<Guid>> Handle(CreateProjectCommand request, RequestHandlerDelegate<ResultViewModel<Guid>> next, CancellationToken cancellationToken)
        {
            var projectExist =  await _repository.Exist(request.Id);
          
            if(projectExist)
            {
                return ResultViewModel<Guid>.Error("The Project Already Exist!");
            }
            return await next();
        }
    }
}
