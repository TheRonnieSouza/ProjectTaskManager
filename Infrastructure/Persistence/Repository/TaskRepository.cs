using Core.Entites;
using Core.Enums;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ProjectTaskManagerDbContext _context;

        public TaskRepository(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Add(tTask task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task.Id; 
        }

        public async Task<bool> Exist(Guid id)
        {
            return await _context.Tasks.AnyAsync(t => t.Id == id &&
                                                            t.Status != EnumTaskStatus.Completed &&
                                                            t.IsDeleted != true);
                                    
        }

        public async Task<List<tTask>> GetAll()
        {
           return await _context.Tasks
                        .Include(t => t.Project)
                        .Include(t => t.Comments)
                        .Include(t => t.Tags)
                        .Where(t => t.Status != EnumTaskStatus.Completed).ToListAsync();
        }

        public async Task<tTask> GetById(Guid id)
        {
            var task = await _context.Tasks.Where(t => t.Status != EnumTaskStatus.Completed && t.IsDeleted != true)
                                     .SingleOrDefaultAsync(ta => ta.Id == id);
            return  task;
        }

        public async Task<tTask> GetDatailsById(Guid id)
        {
            var taskWithProject = await _context.Tasks
                                                 .Include(t => t.Project)
                                                 .SingleOrDefaultAsync(t => t.Id == id);
            return taskWithProject;
        }

        public async Task<bool> TaskExistWithTheSameName(tTask task)
        {
           return  await _context.Tasks.AnyAsync(t => t.Title == task.Title && t.ProjectId == task.ProjectId);
        }

        public async Task Update(tTask task)
        {
            _context.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
