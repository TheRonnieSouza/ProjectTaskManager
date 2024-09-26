using Core.Entites;

namespace Application.Models.Projects.InputModels
{
    public class CreateProjectInputModel
    {
        public Guid id { get; set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public Guid ManagerId { get; private set; }

        public Project ToEntity(CreateProjectInputModel inputModel)
                                    => new(inputModel.id,inputModel.Name, inputModel.Description, inputModel.ManagerId);

    }
}
