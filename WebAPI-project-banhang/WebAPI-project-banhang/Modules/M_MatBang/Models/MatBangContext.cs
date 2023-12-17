using Microsoft.EntityFrameworkCore;
using WebAPI_project_banhang.Modules.M_MatBang.Models;

namespace WebAPI_project_banhang.Modules.M_MatBang.Models
{
    public class MatBangContext: BanhangContext
    {
        public MatBangContext(DbContextOptions<BanhangContext> options)
            : base(options)
        {
        }
        public DbSet<MatBang> MatBangs { get; set; }
    
    }
}
