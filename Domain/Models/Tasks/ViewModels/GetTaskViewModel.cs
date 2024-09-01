using Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Tasks.ViewModels
{
    public class GetTaskViewModel
    {
        public GetTaskViewModel() { }   
        public GetTaskViewModel(Guid id, string title, string description,
                                DateTime deliveryDate, EnumTaskStatus status, 
                                EnumTaskPriority priority, List<Comment> comments,
                                Project project, List<Tag> tags)
        {
            Id = id; Title = title;
            Description = description;
            DeliveryDate = deliveryDate;
            Status = status;
            Priority = priority;
            Comments = comments.Select(c => c.Content).ToList();
            Project = project.Name;
            Tags = tags.Select(t => t.Name).ToList();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DeliveryDate { get; set; }
        public EnumTaskStatus Status { get; set; }
        public EnumTaskPriority Priority { get; set; }
        public List<string>? Comments { get; set; }
        public string? Project {  get; set; }
        public List<string>? Tags { get; set; }
        public static GetTaskViewModel FromEntity(tTask entity) => new(entity.Id, entity.Title,entity.Description, entity.DeliveryDate,
                                                                entity.Status, entity.Priority,entity.Comments,entity.Project, entity.Tags);

    }
}
