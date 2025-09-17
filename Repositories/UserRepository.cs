using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Entities;

namespace UserApi.Repositories
{
    public class UserRepository
    {
        private readonly UserDataContext _context;

        public UserRepository(UserDataContext userContext)
        {
            _context = userContext;
        }

        public async Task Create(UserEntity entity)
        {
           await _context.AddAsync(entity);
           await _context.SaveChangesAsync();
                        
        }

        public async Task<List<UserEntity>> GetUsers()
        {
            return await _context.Users.ToListAsync();
            
        }

        public async Task <UserEntity> ReadById(int id) 
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);         

        }

        public async Task Update(UserEntity entity) 
        {
           
            _context.Users.Update(entity);
           await _context.SaveChangesAsync();

        }

        public async Task Delete(UserEntity entity)
        {
         
            _context.Users.Remove(entity);
           await _context.SaveChangesAsync();

        }
    }
}
