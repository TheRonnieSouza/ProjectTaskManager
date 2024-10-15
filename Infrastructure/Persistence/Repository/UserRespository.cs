using Core.Entites;
using Core.Enums;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class UserRespository : IUserRepository
    {
        private readonly ProjectTaskManagerDbContext _context;
        public UserRespository(ProjectTaskManagerDbContext context) 
        { 
            _context = context;
        }
        public async Task<Guid> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> Exist(Guid id)
        {
           return await _context.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<bool> ExistActiveUser(Guid id)
        {
           return await _context.Users.AnyAsync(u => u.Id == id && u.IsActive && !u.IsDeleted); 
        }

        public async Task<bool> ExistEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetAll()
        {
          return await _context.Users.Where(u => !u.IsDeleted).ToListAsync();
        }

        public async Task<List<User>> GetAllSearch(string emailSearch)
        {
            return await _context.Users.Where(u => u.Email == emailSearch && u.IsActive == true).ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);            
        }

        public async Task<User> GetDetailsById(Guid taskId)
        {
          return  await _context.Users
                                     .Include(u => u.ParticipaitingProjects)
                                     .SingleOrDefaultAsync(u => u.Id == taskId);
        }

        public async Task<bool> ProfileExist(Guid id, Profile profile)
        {
          return await _context.Users.AnyAsync(u => u.Id == id && u.Profile == profile);
        }

        public async Task Update(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
