using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_MatBang.Models;
using WebAPI_project_banhang.Modules.M_MatBang.ViewModels;

namespace WebAPI_project_banhang.Modules.M_MatBang.Services
{
    public interface IMatBangService
    {
        Task<MatBangOutputViewModel> GetMatBangList(MatBangInputViewModel matBangInputViewModel);
        Task<bool> CreateMatBang(CreateMatBangInputViewModel createMatBangInputViewModel);
    }
}
