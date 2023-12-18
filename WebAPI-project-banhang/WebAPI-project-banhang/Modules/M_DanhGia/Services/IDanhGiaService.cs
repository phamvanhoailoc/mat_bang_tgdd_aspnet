using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_DanhGia.ViewModels;



namespace WebAPI_project_banhang.Modules.M_DanhGia.Services
{
    public interface IDanhGiaService
    {
        Task<GetDanhGiaListViewModel> getListDanhGia(FilterDanhGiaViewModel filterDanhGiaViewModel);
    }
}
