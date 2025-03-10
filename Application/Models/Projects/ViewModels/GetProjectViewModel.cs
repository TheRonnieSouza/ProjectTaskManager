﻿using Core.Entites;
using System.Text.Json.Serialization;

namespace Application.Models.Projects.ViewModels
{
    public class GetProjectViewModel
    {
        public GetProjectViewModel() { }    
        public GetProjectViewModel(Guid id, string name, string description,
                                    Guid managerId, DateTime createdDate,
                                    DateTime? completedDate, List<tTask> tasks,
                                    List<User> participants,User manager)
        {
            id = id;
            Name = name;
            Description = description;
            ManagerId = managerId;
            CreatedDate = createdDate;
            CompletedDate = completedDate;
            Tasks = tasks;
            Participants = participants;
            Manager = manager;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid ManagerId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? CompletedDate { get; private set; }

        public List<tTask> Tasks { get; private set; }
        [JsonIgnore]
        public List<User> Participants { get; private set; }
        public User Manager { get; private set; }

        public static GetProjectViewModel FromEntity(Project entity)
                => new(entity.Id, entity.Name, entity.Description, entity.ManagerId,
                    entity.CreatedDate, entity.CompletedDate, entity.Tasks, entity.Participants, entity.Manager);
    }
}
