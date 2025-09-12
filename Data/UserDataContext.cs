using Microsoft.EntityFrameworkCore;
using UserApi.Entities;

namespace UserApi.Data
{
    public class UserDataContext : DbContext
    {
        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
        {
            
        }

        public DbSet<UserEntity> Users { get; set; }


    }
}
