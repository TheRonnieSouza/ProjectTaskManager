using Core.Entites;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectTaskManagerDbContext _context;
        public ProjectRepository(ProjectTaskManagerDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Add(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project.Id;  
        }

        public async Task<bool> Exist(Guid id)
        {
            return await _context.Projects.AnyAsync(x => x.Id == id);
        }

        public Task<List<Project>> GetAll()
        {
            var project = _context.Projects
                                   .Include(t => t.Tasks)
                                   .Include(m => m.Manager)
                                   .Where(p => !p.IsDeleted)
                                   .ToListAsync();
            
            return project;
        }

        public async Task<Project> GetById(Guid id)
        {
           return await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);
        }

        public Task<Project> GetDatailsById(Guid id)
        {
            var project = _context.Projects
                                  .Include(t => t.Tasks)
                                  .Include(m => m.Manager)
                                  .Include(p => p.Participants)
                                  .SingleOrDefaultAsync(p => p.Id == id);

            return project;
        }

        public async Task Update(Project project)
        {
            _context.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
