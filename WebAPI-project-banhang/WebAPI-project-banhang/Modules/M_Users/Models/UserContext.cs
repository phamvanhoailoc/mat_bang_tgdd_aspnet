using Microsoft.EntityFrameworkCore;
using WebAPI_project_banhang.Modules.M_User.Models;

namespace WebAPI_project_banhang.Modules.M_Users.Models
{
    public class UserContext: BanhangContext
    {
        public UserContext(DbContextOptions<BanhangContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    
    }
}
