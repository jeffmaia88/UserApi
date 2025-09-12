using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Entities;

namespace UserApi.Repositories
{
    public class UserRepository
    {
        private readonly UserDataContext _userContext;

        public UserRepository(UserDataContext userContext)
        {
            _userContext = userContext;
        }

        public void Created(UserEntity entity)
        {
            _userContext.Add(entity);
            _userContext.SaveChanges();
                        
        }

        public List<UserEntity> GetUsers()
        {
            return _userContext.Users.ToList();
            
        }

        public UserEntity ReadById(int id) 
        {
            return _userContext.Users.AsNoTracking().FirstOrDefault(x=> x.Id == id);         

        }

        public void Updated(UserEntity entity) 
        {
           
            _userContext.Users.Update(entity);
            _userContext.SaveChanges();

        }

        public void Delete(UserEntity entity)
        {
         
            _userContext.Users.Remove(entity);

        }
    }
}
