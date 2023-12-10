using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.Repositories
{
    public interface ISieuThiRepositories
    {
        public Task<GetSieuThiListViewModel> getSieuThiListRepo(FilterSieuThiViewModel filterSieuThiViewModel);
    }
}
