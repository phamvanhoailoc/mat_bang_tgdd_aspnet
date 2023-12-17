using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_TieuChi.Models;
using WebAPI_project_banhang.Modules.M_TieuChi.ViewModels;

namespace WebAPI_project_banhang.Modules.M_TieuChi.Repositories
{
    public interface ITieuChiRepositories
    {
        Task<List<TieuChi>> GetListTieuChi(InputTieuChiViewModel inputTieuChiViewModel);
    }
}
