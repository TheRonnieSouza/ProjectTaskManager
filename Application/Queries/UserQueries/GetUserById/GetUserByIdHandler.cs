using Application.Models.Users.ViewModels;
using Application.Models;
using MediatR;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UsersViewModels>>
    {
        private readonly ProjectTaskManagerDbContext _context;

        public GetUserByIdHandler(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<UsersViewModels>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id && u.IsActive == true);

            if (user == null)
                return ResultViewModel<UsersViewModels>.Error("Usuario nao encotrado");

            var userViewModel = UsersViewModels.FromEntity(user);

            return ResultViewModel<UsersViewModels>.Success(userViewModel);
        }
    }
}
