using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_TieuChi.ViewModels;

namespace WebAPI_project_banhang.Modules.M_TieuChi.Services
{
    public interface ITieuChiService
    {
        Task<OutputTieuChiViewModel> GetListTieuChi(InputTieuChiViewModel inputTieuChiViewModel);
    }
}
