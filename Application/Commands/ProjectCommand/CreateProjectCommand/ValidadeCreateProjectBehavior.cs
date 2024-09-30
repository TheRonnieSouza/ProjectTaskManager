using Application.Models;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.ProjectCommand.CreateProjectCommand
{
    public class ValidadeCreateProjectBehavior : IPipelineBehavior<CreateProjectCommand, ResultViewModel<Guid>>
    {
        private readonly ProjectTaskManagerDbContext _context;
        public ValidadeCreateProjectBehavior(ProjectTaskManagerDbContext context) 
        {
            context = _context;
        }
        public async Task<ResultViewModel<Guid>> Handle(CreateProjectCommand request, RequestHandlerDelegate<ResultViewModel<Guid>> next, CancellationToken cancellationToken)
        {
            var projectExist =  _context.Projects.Any(p => p.Id == request.Id);
          
            if(!projectExist)
            {
                return ResultViewModel<Guid>.Error("The Project Already Exist!");
            }
            return await next();
        }
    }
}
