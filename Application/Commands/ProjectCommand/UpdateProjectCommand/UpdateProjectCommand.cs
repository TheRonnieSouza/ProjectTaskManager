using Application.Models;
using Core.Entites;
using MediatR;

namespace Application.Commands.ProjectCommand.UpdateProjectCommand
{
    public class UpdateProjectCommand : IRequest<ResultViewModel>
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public DateTime? CompletedDate { get; set; }
        public User Manager { get; set; }
        public Guid ManagerId { get; set; }
        public List<tTask> Tasks { get; set; }
        public Guid ParticipatingId { get; set; }
        public List<User> Participants { get; set; }
    }
}
