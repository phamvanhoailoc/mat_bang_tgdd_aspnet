using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_TieuChi.Models;
using WebAPI_project_banhang.Modules.M_TieuChi.ViewModels;


namespace WebAPI_project_banhang.Modules.M_TieuChi.Repositories
{
    public class TieuChiRepositories : ITieuChiRepositories
    {
        private readonly TieuChiContext _context;

        public TieuChiRepositories(TieuChiContext context)
        {
            _context = context;
        }
        public async Task<List<TieuChi>> GetListTieuChi(InputTieuChiViewModel inputTieuChiViewModel)
        {
            string sql = "EXECUTE dbo.GetTieuchiInfo @maltc";

            return await _context.TieuChi.FromSqlRaw(sql,
                    new SqlParameter("@maltc", inputTieuChiViewModel.IdLoaiTieuChi)

                ).ToListAsync();
        }
    }
}
