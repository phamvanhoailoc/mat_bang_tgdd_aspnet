using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_MatBang.Models;
using WebAPI_project_banhang.Modules.M_MatBang.ViewModels;

namespace WebAPI_project_banhang.Modules.M_MatBang.Repositories
{
    public interface IGetMatBangListRepositories
    {
        public Task<List<MatBang>> FilterMatBangAsync(MatBangInputViewModel matBangInputViewModel, string fromDate, string toDate);
        public Task<int> CountRecordMatBangAsync(MatBangInputViewModel matBangInputViewModel, string fromDate, string toDate);
        public Task<bool> CreateMatBang(CreateMatBangInputViewModel createMatBangInputViewModel);
        // public Task<MatBangId> GetMatBangById(int id);
        //public Task<bool> UpdateMatBangById(InputUpdateMatBangViewModel inputUpdateMatBangViewModel, int id);
    }
}