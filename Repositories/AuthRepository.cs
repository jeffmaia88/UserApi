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

        public async Task<UserEntity> GetByEmail(string email)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }

    }
}
