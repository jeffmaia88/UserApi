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

        public void Create(UserEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
                        
        }

        public List<UserEntity> GetUsers()
        {
            return _context.Users.ToList();
            
        }

        public UserEntity ReadById(int id) 
        {
            return _context.Users.AsNoTracking().FirstOrDefault(x=> x.Id == id);         

        }

        public void Update(UserEntity entity) 
        {
           
            _context.Users.Update(entity);
            _context.SaveChanges();

        }

        public void Delete(UserEntity entity)
        {
         
            _context.Users.Remove(entity);

        }
    }
}
