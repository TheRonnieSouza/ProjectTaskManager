using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.UserCommands.DeleteUserCommand
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user == null)
                return ResultViewModel.Error("The user cannot be deleted or the user not founded");

            user.SetAsDeleted();
            _userRepository.Update(user);  

            return ResultViewModel.Success();
        }
    }
}
