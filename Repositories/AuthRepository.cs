using UserApi.Entities;
using UserApi.Data;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;


namespace UserApi.Repositories
{
    public class AuthRepository
    {
        private readonly UserDataContext _context;

        public AuthRepository(UserDataContext context)
        {
            _context = context;
        }

        public UserEntity GetByEmail(string email)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(x => x.Email == email);
        }

    }
}
