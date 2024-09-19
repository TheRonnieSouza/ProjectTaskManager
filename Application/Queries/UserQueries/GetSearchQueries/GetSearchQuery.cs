using Application.Models;
using Application.Models.Users.ViewModels;
using MediatR;

namespace Application.Queries.UserQueries.GetSearchQueries
{
    public class GetSearchQuery :IRequest<ResultViewModel<List<UsersViewModels>>>
    {
        public GetSearchQuery(string search) 
        {
            Search = search;
        }
        public string Search { get; private set; }
    }
}
