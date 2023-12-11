using Microsoft.EntityFrameworkCore;
using WebAPI_project_banhang.Modules.M_User.Models;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.Models
{
    public class SieuThiContext : BanhangContext
    {
        public SieuThiContext(DbContextOptions<BanhangContext> options)
            : base(options)
        {
        }
        public DbSet<SieuThi> SieuThi { get; set; }
        public DbSet<SieuThiById> SieuThiById { get; set; }
    }
}
