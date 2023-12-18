using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_DanhGia.Models;
using WebAPI_project_banhang.Modules.M_DanhGia.ViewModels;

namespace WebAPI_project_banhang.Modules.M_DanhGia.Repositories
{
    public interface IDanhGiaRepositories
    {
        public Task<List<DanhGia>> FilterDanhGiaAsync(FilterDanhGiaViewModel filterDanhGiaViewModel, string fromDate, string toDate);
        public Task<int> CountRecordDanhGiaAsync(FilterDanhGiaViewModel filterDanhGiaViewModel, string fromDate, string toDate);

    }
}
