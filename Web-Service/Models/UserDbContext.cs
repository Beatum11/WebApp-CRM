using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Web_Service.Models
{
    public class UserDbContext : IdentityDbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

    }
}
