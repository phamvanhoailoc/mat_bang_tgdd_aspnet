using Microsoft.EntityFrameworkCore;

namespace WebAPI_project_banhang
{
    public class BanhangContext : DbContext
    {
        public BanhangContext(DbContextOptions options) : base(options)
        {
        }
    }
}
