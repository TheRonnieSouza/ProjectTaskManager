using Application.Models.Users.ViewModels;
using Application.Models;
using MediatR;
using Infrastructure.Persistence;

namespace Application.Queries.UserQueries.GetSearchQueries
{
    public class GetSearchHandler : IRequestHandler<GetSearchQuery, ResultViewModel<List<UsersViewModels>>>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public GetSearchHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<UsersViewModels>>> Handle(GetSearchQuery request, CancellationToken cancellationToken)
        {
            //TODO 
            //mecanismo de busca

            var user = _context.Users.Where(u => u.Email == request.Search && u.IsActive == true);

            if (user == null)
                return ResultViewModel<List<UsersViewModels>>.Error("O usuario nao foi encontrado");

            var usersViewModel = user.Select(UsersViewModels.FromEntity).ToList();

            return ResultViewModel<List<UsersViewModels>>.Success(usersViewModel);
        }
    }
}
