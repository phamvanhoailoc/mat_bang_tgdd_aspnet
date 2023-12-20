using Microsoft.EntityFrameworkCore;

namespace WebAPI_project_banhang.Modules.M_DanhGia.Models
{
    public class DanhGiaContext : BanhangContext
    {
        public DanhGiaContext(DbContextOptions<BanhangContext> options)
            : base(options)
        {
        }
        public DbSet<DanhGia> DanhGia { get; set; }
    }
}
