using Application.Models;
using Core.Repositories;
using MediatR;

namespace Application.Commands.UserCommands.UpdateUserCommand
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            user.UpdateUser(request.Name, request.Email);
            _userRepository.Update(user);

            return  ResultViewModel.Success();
        }
    }
}
