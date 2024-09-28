using Application.Models;
using Application.Models.Projects.ViewModels;
using MediatR;

namespace Application.Queries.ProjectQueries.GetAllProjectQuery
{
    public class GetAllProjectQuery : IRequest<ResultViewModel<List<GetProjectViewModel>>>
    {
       
    }
}
