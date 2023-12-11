using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Models;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.Repositories
{
    public interface ISieuThiRepositories
    {
        public Task<List<SieuThi>> FilterSieuThiAsync(FilterSieuThiViewModel filterSieuThiViewModel, string fromDate, string toDate);
        public Task<int> CountRecordSieuThiAsync(FilterSieuThiViewModel filterSieuThiViewModel, string fromDate, string toDate);
        public Task<SieuThiById> GetSieuThiById(int id);
        public Task<bool> UpdateSieuThiById(InputCapNhatSieuThiViewModel inputCapNhatSieuThiViewModel, int id);
    }
}
