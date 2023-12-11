using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels;
using WebAPI_project_banhang.Modules.M_User.Models;


namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.Services
{
    public interface ISieuThiService
    {
        Task<GetSieuThiListViewModel> getListSieuThi(FilterSieuThiViewModel filterSieuThiViewModel);
        Task<OutputGetSieuThiByIdViewModel> getSieuThiById(int id);
    }
}
