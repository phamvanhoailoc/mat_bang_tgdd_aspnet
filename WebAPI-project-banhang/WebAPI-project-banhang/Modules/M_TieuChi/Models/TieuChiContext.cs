using Microsoft.EntityFrameworkCore;

namespace WebAPI_project_banhang.Modules.M_TieuChi.Models
{
    public class TieuChiContext : BanhangContext
    {
        public TieuChiContext(DbContextOptions<BanhangContext> options)
           : base(options)
        {
        }
        public DbSet<TieuChi> TieuChi { get; set; }

    }
}
